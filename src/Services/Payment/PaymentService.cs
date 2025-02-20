using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SDA_Backend_Project.src.Repository;
using SDA_Backend_Project.src.Utils;
using static SDA_Backend_Project.src.DTO.PaymentDTO;

namespace SDA_Backend_Project.src.Services.Payment
{
    public class PaymentService : IPaymentService
    {
        protected readonly PaymentRepository _paymentRepo;
        protected readonly IMapper _mapper;
        public PaymentService (PaymentRepository paymentRepo, IMapper mapper)
        {
            _paymentRepo = paymentRepo;
            _mapper = mapper;
        }

        // Create a payment
        public async Task <PaymentReadDto> CreateOneAsync(PaymentCreateDto createDto)
        {
            Entity.Cart cart = await _paymentRepo.GetCart(createDto.CartId);
            if (cart == null)
            {
                CustomException.NotFound("Cart not found.");           
            }

            if (createDto.CouponId != null) 
            {
                src.Entity.Coupon coupon = await _paymentRepo.GetCoupon(createDto.CouponId);
                if (coupon != null && coupon.IsActive)
                {
                    createDto.TotalPrice = cart.TotalPrice * (1 - coupon.DiscountPercentage);// update total price with coupon
                }
                else
                {
                    createDto.TotalPrice = cart.TotalPrice; // update total price without coupon if (coupon == null) or (coupon.IsActive = fales}
                }
            }
            else
            {
                createDto.TotalPrice = cart.TotalPrice; // update total price without coupon 
            }
            var payment = _mapper.Map<PaymentCreateDto, Entity.Payment>(createDto);
            var paymentCreated = await _paymentRepo.CreateOneAsync(payment);
            return _mapper.Map<Entity.Payment,PaymentReadDto>(paymentCreated);
        }

        // Get all payments
        public async Task<List<PaymentReadDto>> GetAllAsync()
        {
            var paymentList= await _paymentRepo.GetAllAsync();
            return _mapper.Map<List<Entity.Payment>, List<PaymentReadDto>>(paymentList);
        }

        // Get a payment by id 
        public async Task<PaymentReadDto> GetByIdAsync(Guid paymentId)
        {
            var foundPayment = await _paymentRepo.GetByIdAsync(paymentId);
            return _mapper.Map<Entity.Payment, PaymentReadDto> (foundPayment);
        }

        // Update a payment
        public async Task<bool> UpdateOneAsync(Guid paymentId, PaymentUpdateDto updateDto)
        {
            Entity.Cart cart = await _paymentRepo.GetCart(updateDto.CartId);
            var foundPayment = await _paymentRepo.GetByIdAsync(paymentId);
            if (foundPayment is null)
            {
                CustomException.NotFound("Payment not found"); 
            }
            
            if (updateDto.CouponId != null) 
            {
                Entity.Coupon coupon = await _paymentRepo.GetCoupon(updateDto.CouponId);
                if (coupon != null && coupon.IsActive)
                {
                    updateDto.TotalPrice = cart.TotalPrice * (1 - coupon.DiscountPercentage);// update total price with coupon
                }
                else
                {
                    updateDto.TotalPrice = cart.TotalPrice; // update total price without coupon if (coupon == null) or (coupon.IsActive = fales}
                }
            }
            else
            {
                updateDto.TotalPrice = cart.TotalPrice; // update total price without coupon 
            }
            _mapper.Map(updateDto, foundPayment);
            var isUpdated = await _paymentRepo.UpdateOneAsync(foundPayment);
            return isUpdated;
        }

        // Delete a payment by id
        public async Task<bool> DeleteOneAsync(Guid paymentId)
        {
        var foundPayment = await _paymentRepo.GetByIdAsync(paymentId);
           bool IsDeleted = await _paymentRepo.DeleteOneAsync(foundPayment);
           if(IsDeleted)
            {        
                return true;
            }
           return false;
        }
    }
}

