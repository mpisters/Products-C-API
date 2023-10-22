using Products.Persistence;
using Products.Persistence.Models;

namespace Products.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/reviews")]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly IRepository<Review> _reviewRepository;

    public ReviewController(IRepository<Review> reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Review>> GetReviews()
    {
        return Ok(_reviewRepository.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReview(int id)
    {
        var review = await _reviewRepository.GetById(id);

        if (review == null)
        {
            return NotFound();
        }

        return review;
    }

    [HttpPost]
    public async Task<ActionResult<Review>> CreateReview(Review review)
    {
        await _reviewRepository.Add(review);

        return CreatedAtAction("GetReview", new { id = review.Id }, review);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReview(int id, Review review)
    {
        if (id != review.Id)
        {
            return BadRequest();
        }

        try
        {
            _reviewRepository.Update(review);
        }
        catch (Exception e)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
        try
        {
            await _reviewRepository.Delete(id);
        }
        catch (Exception e)
        {
            return NotFound();
        }

        return NoContent();
    }
    
    [HttpGet("summary/{productID}")]
    public async Task<ActionResult<ReviewSummary>> GetReviewSummary(int productID)
    {
        var reviews = await _reviewRepository.GetAll(productID);

        if (reviews.Count == 0)
        {
            return NotFound("No reviews found for the given product.");
        }

        double averageScore = reviews.Average(r => r.Score);
        double percentageRecommendation = (double)reviews.Count(r => r.RecommendProduct) / reviews.Count * 100;

        var summary = new ReviewSummary(productID, 
            Math.Round(averageScore, 2),
            Math.Round(percentageRecommendation, 2));
       

        return Ok(summary);
    }
}