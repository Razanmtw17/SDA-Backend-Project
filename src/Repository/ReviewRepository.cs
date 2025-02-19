using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SDA_Backend_Project.src.Database;
using SDA_Backend_Project.src.Entity;
using SDA_Backend_Project.src.Utils;

namespace SDA_Backend_Project.src.Repository
{
    public class ReviewRepository
    {
        protected DbSet<Review> _review;
        protected DbSet<Product> _products;
        protected DatabaseContext _databaseContext;

        public ReviewRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _review = databaseContext.Set<Review>();
            _products = databaseContext.Set<Product>();
        }

        public async Task<Review> CreateReviewAsync(Review review)
        {
            await _review.AddAsync(review);
            await _databaseContext.SaveChangesAsync();
            return review;
        }


        public async Task<Review?> GetReviewByIdAsync(Guid id)
        {
            return await _review.FirstOrDefaultAsync(x => x.ReviewId == id);
        }
        public async Task<List<Review>> GetReviewByProductIdAsync(Guid productId)
        {
            return await _review.Where(r => r.ProductId == productId).ToListAsync();
        }
        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _review.ToListAsync();
        }
        public async Task UpdateProductReviewAsync(Guid id)
        {
            var product = await _products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (product != null)
            {
                var reviewsForProduct = await _review.Where(r => r.ProductId == id).ToListAsync();// all reviews for this product
                product.AverageRating = (decimal)reviewsForProduct.Average(r => r.Rating);

                _products.Update(product);
                await _databaseContext.SaveChangesAsync();
            }
            else
            {
                throw CustomException.BadRequest("Product not found");
            }


        }


        public async Task<bool> DeleteReviewAsync(Review review)
        {
            _review.Remove(review);
            await _databaseContext.SaveChangesAsync();
            return true;
        }

        public async Task<Review?> UpdateReviewAsync(Review review)
        {
            _review.Update(review);
            await _databaseContext.SaveChangesAsync();
            return review;
        }

    }
}