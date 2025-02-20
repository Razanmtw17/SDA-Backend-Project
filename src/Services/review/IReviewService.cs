using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SDA_Backend_Project.src.DTO.ReviewDTO;

namespace SDA_Backend_Project.src.Services.review
{
    public interface IReviewService
    {
          //create new review
        Task<ReadReviewDto> CreateReviewAsync(CreateReviewDto createDto);

        //get all Reviews
        Task<List<ReadReviewDto>> GetAllReviewsAsync();

        //get review by id
        Task<ReadReviewDto> GetReviewByIdAsync(Guid id);

        //get all reviews by product id
        Task<List<ReadReviewDto>> GetReviewByProductIdAsync(Guid id);

        //delete review
        Task<bool> DeleteReviewAsync(Guid id);
        //update review
        Task<ReadReviewDto> UpdateReviewAsync(Guid id, UpdateReviewDto updateDto);
    }
}