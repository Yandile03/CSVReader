using CSVReader.Data;
using CSVReader.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Formats.Asn1.AsnWriter;

namespace CSVReader.Controllers
{
    [ApiController]
    [Route("Api/score")]
    public class ScoreController : Controller
    {
        private readonly AppDbContex _dbContext;

        public ScoreController(AppDbContex dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult AddScore([FromBody] DataScores score)
        {
            _dbContext.DataScores.Add(score);
            _dbContext.SaveChanges();
            return Ok(score);
        }

        [HttpGet("{name}")]
        public IActionResult GetScore(string name)
        {
            var score = _dbContext.DataScores.FirstOrDefault(s => s.Name == name);
            return score != null ? Ok(score) : NotFound();
        }

        [HttpGet("top-scorers")]
        public IActionResult GetTopScorers()
        {
            var maxScore = _dbContext.DataScores.Max(s => s.Mark);
            var topScorers = _dbContext.DataScores.Where(s => s.Mark == maxScore).OrderBy(s => s.Name).ToList();
            return Ok(topScorers);
        }
    }
}
