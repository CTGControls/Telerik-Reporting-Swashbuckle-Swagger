using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;


namespace CTG.TRSS.SharedCode.APIModels
{
    [Serializable]
    public class AppUser
    {
        //The ID of user (guid)
        [Display(Name = "Id")]
        [DataType(DataType.Text)]
        [BindProperty]
        public System.Guid Id { get; set; }

        //The First Name of the user (string)
        [Display(Name = "Id")]
        [DataType(DataType.Text)]
        [BindProperty]
        public string FirstName { get; set; }

        //The Last Name of the user (string)
        [Display(Name = "Id")]
        [DataType(DataType.Text)]
        [BindProperty]
        public string LastName { get; set; }
    }
}
