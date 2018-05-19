﻿using Northwind.Logic.Common;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Logic.Model
{
    public class Employee : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string About { get; set; }
        public virtual Department Department { get; set; }
        public virtual bool IsFullTimer { get; set; }

        protected virtual IList<ProjectInvolvement> InvolvementsInternal { get; set; }
        public virtual IReadOnlyList<ProjectInvolvement> Involvements
        {
            get { return InvolvementsInternal.ToList(); }
        }

        //TODO

        public virtual string Name
        {
            get { return $"{FirstName} {LastName}"; }
        }

        //TODO
    }
}
