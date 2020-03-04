using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Eaton_DG_PCC.Model
{
    public class User
    {
        public int ID { get; set; }
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "UserName not null")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password not null")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^\w+$", ErrorMessage = "The password format is incorrect. It can only be alphanumeric or underlined.")]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Inconsistent passwords.")]
        public string ConfirmPassword { get; set; }







        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }


        public string RoleNum { get; set; }
        public string RoleName { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CreateTime { get; set; }
        public int LoginCount { get; set; }
        public string Picture { get; set; }
        public string UpdateTime { get; set; }
        public string DepartNum { get; set; }
        public string DepartName { get; set; }
        public string Remark { get; set; }



        public string Login()
        {
            //该方法应从数据库中对比用户名和密码,并取得用户权限列表
            //这里为了简单直接对比字符串并返回权限列表,返回NULL则说明用户名或者密码错误
            //权限列表即为用,分割的权限名称
            string result = null;

            if (this.UserName == "guest" & this.Password == "guest")
                result = "Add";

            if (this.UserName == "admin" & this.Password == "admin")
                result = "Add,Edit";

            return result;
        }
    }
}