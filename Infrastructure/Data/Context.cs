using Domain.AggregatesModel.AnswerAggregate;
using Domain.AggregatesModel.InterviewAggregate;
using Domain.AggregatesModel.QuestionAggregate;
using Domain.AggregatesModel.ResultAggregate;
using Domain.AggregatesModel.SurveyAggregate;
using Infrastructure.Data.Configs;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

internal sealed class Context : DbContext
{
  public Context(DbContextOptions<Context> options) : base(options)
  {
    Database.EnsureCreated();
  }

  public DbSet<Answer> Answers { get; set; }
  public DbSet<Question> Questions { get; set; }
  public DbSet<Survey> Surveys { get; set; }
  public DbSet<Result> Results { get; set; }
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.UseIdentityByDefaultColumns();
    
    modelBuilder.ApplyConfiguration(new AnswerConfiguration());
    modelBuilder.ApplyConfiguration(new QuestionConfiguration());
    modelBuilder.ApplyConfiguration(new SurveyConfiguration());
    modelBuilder.ApplyConfiguration(new ResultConfiguration());
    modelBuilder.ApplyConfiguration(new InterviewConfiguration());
    
    // Создаем начальные данные для Survey
    var survey = new Survey("Личный опрос") { Id = 1 };

    // Создаем начальные данные для Questions
    var question2 = new Question("Ваш возраст", survey.Id, null) { Id = 2 };
    var question1 = new Question("В каком регионе Вы проживаете?", survey.Id, question2.Id) { Id = 1 }; 
    
    // Создаем начальные данные для Answers
    var answer1 = new Answer(question1.Id, "Москва") { Id = 1 };
    var answer2 = new Answer(question1.Id, "Московская область") { Id = 2 };
    var answer3 = new Answer(question1.Id, "Санкт-Петербург") { Id = 3 };
    var answer4 = new Answer(question1.Id, "Ленинградская область") { Id = 4 };

    var answer5 = new Answer(question2.Id, "От 10 до 18") { Id = 5 };
    var answer6 = new Answer(question2.Id, "От 18 и далее") { Id = 6 };

    // Создаем начальные данные для Interview
    var interview = new Interview("Иван Иванов", survey.Id) { Id = 1 };

    // Добавляем seed data для Survey, Questions, Answers и Interview
    modelBuilder.Entity<Survey>().HasData(survey);
    modelBuilder.Entity<Question>().HasData(question1, question2);
    modelBuilder.Entity<Answer>().HasData(answer1, answer2, answer3, answer4, answer5, answer6);
    modelBuilder.Entity<Interview>().HasData(interview);
    
    base.OnModelCreating(modelBuilder);
  }
}