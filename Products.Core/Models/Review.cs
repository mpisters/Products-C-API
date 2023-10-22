namespace Products.Core.Models;

public class Review
{
    public int Score { get; set; }
    public string ReviewTitle { get; set; }
    public string Comment { get; set; }
    public bool RecommendProduct { get; set; }
}