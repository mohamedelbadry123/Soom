using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Interfaces.ViewModel.UserVM
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string Error { get; set; }
    }
}
