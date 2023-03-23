using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hennis_Models.Dto
{
    public class OnlineApplicationDto
    {

        #region Basic Form


        public int Id { get; set; }
        public DateTime DateSubmitted { get; set; }

        [Required]
        public string LocationSubmitted { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Required]

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name="Professional License Number")]
        public string ProfessionalLicenseNumber { get; set; }
        [Required]

        [Display(Name="Best time to contact you at home")]
        
        public string ContactTime { get; set; }
        [Display(Name="Position Applied For")]
        [Required]
        public string Position { get; set; }
        [Required]
        [Display(Name="If you are under 18 years of age, can you provide required proof of your eligibility to work")]
        public string CanProvideProof { get; set; }
        [Required]

        [Display(Name= "Have you ever filed an application with us before?")]
        public string FilledApplicationBefore { get; set; }

        [Display(Name = "If yes, please provide date")]

        public string? FilledApplicationBeforeDate { get; set; }

        [Display(Name= "Have you ever been employed with us before?")]
        [Required]

        public string EmployeedBefore { get; set; }

        [Display(Name = "If yes, please provide date")]

        public string? EmployeedBeforeDate { get; set; }

        [Display(Name = "Do any of your friends relatives, other than spouse, work here?")]

        public string FriendsWorkHere { get; set; }

        [Display(Name = "If yes, state name, relationship and location")]

        public string? FriendsWorkHereName { get; set; }

        [Display(Name ="Are you currenty employed?")]
        public string CurrentlyEmployed { get; set; }

        [Display(Name = "If yes, may we contact your current employer?")]
        public string ContactEmployer { get; set; }

        [Display(Name = "Are you prevented from lawfully becoming employed in the United State because of VISA or Immigration Status?")]
        public string LawfulEmployee { get; set; }
        [Display(Name = "Are you currently laid off and subject to recall?")]
        public string CurrentlyLaidOff { get; set; }

        [Display(Name = "Date available for work")]
        public string DateAvailable { get; set; }

        [Display(Name = "What is your desired salary range?")]
        public string DesiredSalary { get; set; }

        public bool FullTime { get; set; }
        public bool FullTimeFirst { get; set; }
        public bool FullTimeSecond { get; set; }
        public bool FullTimeThird { get; set; }

        public bool PartTime { get; set; }
        public bool PartTimeFirst { get; set; }
        public bool PartTimeSecond { get; set; }
        public bool PartTimeThird { get; set; }

        public bool AsNeededTime { get; set; }
        public bool AsNeededTimeFirst { get; set; }
        public bool AsNeededTimeSecond { get; set; }
        public bool AsNeededTimeThird { get; set; }
        #endregion

        #region Work Experience
        [Display(Name = "Employer")]
        public string? Employer1 { get; set; }

            [Display(Name="Address")]
            public string? Address1 { get; set; }

        [Display(Name ="Telephone Number(s)")]
        public string? TelephoneNumber1 { get; set; }
        [Display(Name ="Starting/Present Job Title")]
        public string? JobTitle1 { get; set; }
        [Display(Name="Supervisor/Manager")]
        public string? Supervisor1 { get; set; }

        [Display(Name="May we contact?")]
        public string? MayWeContact1 { get; set; }
        [Display(Name ="Reason for Leaving")]
        public string? ReasonForLeaving1 { get; set; }
        [Display(Name ="Start Date")]
        public string? StartDate1 { get; set; }

        [Display(Name ="End Date")]
        public string? EndDate1 { get; set; }
        [Display(Name ="Beginning")]
        public string? BeginningSalary1 { get; set; }
        [Display(Name ="Ending")]
        public string? EndingSalary1 { get; set; }
        [Display(Name ="Duties/Work Performed")]
        public string? Duties1 { get; set; }

        [Display(Name = "Employer")]
        public string? Employer2 { get; set; }

        [Display(Name = "Address")]
        public string? Address2 { get; set; }

        [Display(Name = "Telephone Number(s)")]
        public string? TelephoneNumber2 { get; set; }
        [Display(Name = "Starting/Present Job Title")]
        public string? JobTitle2 { get; set; }
        [Display(Name = "Supervisor/Manager")]
        public string? Supervisor2 { get; set; }

        [Display(Name = "May we contact?")]
        public string? MayWeContact2 { get; set; }
        [Display(Name = "Reason for Leaving")]
        public string? ReasonForLeaving2 { get; set; }
        [Display(Name = "Start Date")]
        public string? StartDate2 { get; set; }

        [Display(Name = "End Date")]
        public string? EndDate2 { get; set; }
        [Display(Name = "Beginning")]
        public string? BeginningSalary2 { get; set; }
        [Display(Name = "Ending")]
        public string? EndingSalary2 { get; set; }
        [Display(Name = "Duties/Work Performed")]
        public string? Duties2 { get; set; }

        [Display(Name = "Employer")]
        public string? Employer3 { get; set; }

        [Display(Name = "Address")]
        public string? Address3 { get; set; }

        [Display(Name = "Telephone Number(s)")]
        public string? TelephoneNumber3 { get; set; }
        [Display(Name = "Starting/Present Job Title")]
        public string? JobTitle3 { get; set; }
        [Display(Name = "Supervisor/Manager")]
        public string? Supervisor3 { get; set; }

        [Display(Name = "May we contact?")]
        public string? MayWeContact3 { get; set; }
        [Display(Name = "Reason for Leaving")]
        public string? ReasonForLeaving3 { get; set; }
        [Display(Name = "Start Date")]
        public string? StartDate3 { get; set; }

        [Display(Name = "End Date")]
        public string? EndDate3 { get; set; }
        [Display(Name = "Beginning")]
        public string? BeginningSalary3 { get; set; }
        [Display(Name = "Ending")]
        public string? EndingSalary3 { get; set; }
        [Display(Name = "Duties/Work Performed")]
        public string? Duties3 { get; set; }


        #endregion

        #region Education
        public string? HighSchoolName { get; set; }
        public string? HighSchoolStudy { get; set; }
        public string? HighSchoolYearsComplete { get; set; }
        public string? HighSchoolDiploma { get; set; }

        public string? UnderGradName { get; set; }
        public string? UnderGradStudy { get; set; }
        public string? UnderGradYearsComplete { get; set; }
        public string? UnderGradDiploma { get; set; }

        public string? GraduateName { get; set; }
        public string? GraduateStudy { get; set; }
        public string? GraduateYearsComplete { get; set; }
        public string? GraduateDiploma { get; set; }
        public string? TechnicalName { get; set; }
        public string? TechnicalStudy { get; set; }
        public string? TechnicalYearsComplete { get; set; }
        public string? TechnicalDiploma { get; set; }

        public string? OtherName { get; set; }
        public string? OtherStudy { get; set; }
        public string? OtherYearsComplete { get; set; }
        public string? OtherDiploma { get; set; }
        #endregion

        #region Life Experience
        public string? SpecializedTraning { get; set; }
        public string? JobRelatedTraining { get; set; }
        public string? ProfessionalActivities { get; set; }
        public string? JobRelatedSkills { get; set; }
        #endregion

        #region References
        [Display(Name="Reference 1")]
        public string Reference1Name { get; set; }
        [Display(Name="Reference 1 - Phone")]
        public string Reference1Phone { get; set; }
        [Display(Name="Reference 1 - Occupation")]
        public string Reference1Occupation { get; set; }
        [Display(Name="Reference 1 - Time to Call")]
        public string Reference1TimeToCall { get; set; }

        [Display(Name = "Reference 2")]
        public string Reference2Name { get; set; }
        [Display(Name = "Reference 2 - Phone")]
        public string Reference2Phone { get; set; }
        [Display(Name = "Reference 2 - Occupation")]
        public string Reference2Occupation { get; set; }
        [Display(Name = "Reference 2 - Time to Call")]
        public string Reference2TimeToCall { get; set; }

        [Display(Name = "Reference 3")]
        public string Reference3Name { get; set; }
        [Display(Name = "Reference 3 - Phone")]
        public string Reference3Phone { get; set; }
        [Display(Name = "Reference 3 - Occupation")]
        public string Reference3Occupation { get; set; }
        [Display(Name = "Reference 3 - Time to Call")]
        public string Reference3TimeToCall { get; set; }
        #endregion

        [Required]
        [MinLength(3,ErrorMessage ="Please enter valid digital signature")]
        public string Signature { get; set; }


    }
}
