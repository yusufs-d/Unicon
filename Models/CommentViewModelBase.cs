using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unicon.Data;

namespace Unicon.Models
{
    public class CommentViewModelBase
    {
        public List<Comment>? Comments { get; set; }

        public Comment? CommentToAdd {get;set;}
    }
}