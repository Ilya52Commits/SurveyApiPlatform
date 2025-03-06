using System.ComponentModel.DataAnnotations;

namespace API.RequestModels.Questions;

public class ContentRequest
{
    [Required(ErrorMessage = "Question ID is required")]
    public int QuestionId { get; set; }
}