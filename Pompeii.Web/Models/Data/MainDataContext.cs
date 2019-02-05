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

    public class Team : Entity
    {
        public string Name { get; set; }
        public string TimeZoneInfoId {get;set;}
    }



    public class StandupTemplate : Entity
    {
        public Guid TeamId { get; set; }
        public string Name { get;set; }
        public List<StandupTemplateDay> Days {get;set;} = new List<StandupTemplateDay>();
    }

    public class StandupTeamMemberResponse : Entity
    {
        public DateTimeOffset SubmittedOn {get;set;}
        public DateTimeOffset TargetStandupDate {get;set;}
        public StandupTemplate StandupTemplate { get; set; }
        public Guid StandupTemplateId {get;set;}
        public TeamMember TeamMember {get;set;}
        public Guid TeamMemberId {get;set;}
        public ResponseType Type {get;set;}
        public string Response {get;set;}
    }

    public enum ResponseType
    {
        Text,
        Video,
        Audio
    }

    public class StandupTemplateDay : Entity
    {
        public Guid StandupTemplateId { get; set; }
        public StandupTemplate StandupTemplate {get;set;}
        public DayOfWeek DayOfTheWeek {get;set;}
        public int NotificationHour {get;set;}
        public int NotificationMinute {get;set;}
    }

    public class User : Entity 
    {
        public string ExternalId {get;set;}
        public string DisplayName {get;set;}
    }

    public class TeamMember : Entity
    {
        public Guid TeamId {get;set;}
        public Team Team {get;set;}
        public Guid UserId {get;set;}
        public User User {get;set;}
    }
     
    public class MainDataContext : DbContext 
    {
        public DbSet<Team> Teams {get;set;}
        public DbSet<TeamMember> TeamMembers {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<StandupTemplate> StandupTemplates {get;set;}
        public DbSet<StandupTemplateDay> StandupTemplateDays {get;set;}
    }
}
