using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pompeii.Web.Models.Data
{
    
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public Guid? TenantId {get;set;}
        public bool Deleted {get;set;}
        public DateTimeOffset DateCreated {get;set;}

    }

    public class Project : Entity
    {
        public string Name { get; set; }
        public string TimeZoneInfoId {get;set;}
        public StandupConfiguration StandupConfiguration { get; set; } = new StandupConfiguration();
        public List<ProjectMember> Members { get; set; } = new List<ProjectMember>();
    }

    public enum ResponseType
    {
        Text,
        Video,
        Audio
    }

    public class StandupConfiguration : Entity
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public DayOfWeek[] DaysOfTheWeek {get;set;}
        public int NotificationHour {get;set;}
        public int NotificationMinute {get;set;}
    }

    public class StandupQuestion : Entity
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public string QuestionText { get; set; }
        public bool ResponseRequired { get; set; } 
    }


    public class StandupQuestionResponse : Entity
    {
        public DateTimeOffset SubmittedOn { get; set; }
        public DateTimeOffset TargetStandupDate { get; set; }
        public Guid QuestionId { get; set; }
        public StandupQuestion Question { get; set; }
        public ProjectMember ProjectMember { get; set; }
        public Guid ProjectMemberId { get; set; }
        public ResponseType Type { get; set; }
        public string Response { get; set; }
    }
 
    public class User : Entity 
    {
        public string ExternalId {get;set;}
        public string DisplayName {get;set;}
    }

    public class ProjectMember : Entity
    {
        public Guid ProjectId {get;set;}
        public Project Project {get;set;}
        public Guid UserId {get;set;}
        public User User {get;set;}
        public string Role { get; set; }
    }
     
    public class MainDataContext : DbContext 
    {
        public DbSet<User> Users {get;set;}
        public DbSet<Project> Projects {get;set;}
        public DbSet<ProjectMember> ProjectMembers {get;set;}
        public DbSet<StandupConfiguration> StandupConfigurations { get; set; }
        public DbSet<StandupQuestion> StandupQuestions { get; set; }
        public DbSet<StandupQuestionResponse> StandupQuestionResponses { get; set; }
    }
}
