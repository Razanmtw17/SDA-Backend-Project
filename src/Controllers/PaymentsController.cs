using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SDA_Backend_Project.src.Services.Payment;
using static SDA_Backend_Project.src.DTO.PaymentDTO;

namespace SDA_Backend_Project.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentsController : ControllerBase
    {
         protected readonly IPaymentService _paymentService;
        public PaymentsController(IPaymentService service)
        {
            _paymentService = service;
        }

        // Get all payments      
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<List< PaymentCreateDto>>>GetAllAsync()
        {
            var paymentList = await _paymentService.GetAllAsync();
            return Ok(paymentList);
        }

        // Get a payment by its id
        [Authorize(Roles = "Admin")] 
        [HttpGet("{paymentId}")]
        public async Task<ActionResult<PaymentReadDto>>GetByIdAsync([FromRoute] Guid paymentId)
        {
            var payment = await _paymentService.GetByIdAsync (paymentId);
            return Ok(payment);
        }

        // Add a new payment       
        [Authorize(Roles = "Admin, User")] 
        [HttpPost]
        public async Task<ActionResult<PaymentReadDto>> CreateOne([FromBody] PaymentCreateDto createDto)
        {
            var paymentCreated = await _paymentService.CreateOneAsync(createDto);
            return Created($"api/v1/payments/{paymentCreated.PaymentId}",paymentCreated);
        }

        // Update a payment using its id        
        [Authorize(Roles = "Admin")]
        [HttpPut("{paymentId}")]
        public async Task<ActionResult<PaymentReadDto>> UpdateOneAsync([FromRoute] Guid paymentId,[FromBody] PaymentUpdateDto updateDto)
        {
             await _paymentService.UpdateOneAsync(paymentId, updateDto);
            var updatedPayment = await _paymentService.GetByIdAsync(paymentId); // Assuming you have a method to fetch the updated category
            return Ok(updatedPayment);
        }

        // Delete a payment using its id        
        [Authorize(Roles = "Admin")] 
        [HttpDelete("{paymentId}")]
        public async Task<IActionResult> DeleteOneAsync([FromRoute] Guid paymentId)
        {
            await _paymentService.DeleteOneAsync(paymentId);
            return NoContent(); 
        }
    }

}
