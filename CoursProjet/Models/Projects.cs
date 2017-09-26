using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoursProjet.Models
{
    public class Projects
    {
        public int ID { get; set; }
        public Users Athor { get; set; }
        public string NameProject { get; set; }
        public DateTime Date { get; set; }
        public int CurrentDonate { get; set; }
        public int NeedMoney { get; set; }
        public string Goal { get; set; }
        public EStatus Status { get; set; }
        public ECategory Category { get; set; }
        public Comments Comment { get; set; }
        public Ratings Raiting { get; set; }
       
    }


    public enum EStatus {

        Active,
        Succses,
        Fail,
        
    }
    public enum ECategory {
         All,
        [Display(Name = "Bussines")]
        Bussines,
        [Display(Name = "Games")]
        Games,
        [Display(Name = "Education")]
        Education,
        [Display(Name = "Art")]
        Art }


    public class Comments
    {
        public int ID { get; set; }
        public Users User { get; set; }
        public Projects Project { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }


    public class Ratings
    {
        public int ID { get; set; }
        public Users User { get; set; }
        public Projects Project { get; set; }
        public int Rating { get; set; }
    }


    public class Tags
    {
        public int ID { get; set; }
        public string Tag { get; set; }
    }


    public class TagRelation
    {
        public int ID { get; set; }
        public Projects Project { get; set; }
        public Tags Tag { get; set; }
    }


    public class Donate
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int DonateSum { get; set; }

    }


    public class News
    {
        public int ID { get; set; }
        public Projects Project { get; set; }
        public string Text { get; set; }
    }


    public class Subscribers
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
    }
}
        
    
