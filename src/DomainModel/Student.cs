﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel
{
    public class Student : Entity
    {
        public string Email { get; }
        public string Name { get; private set; }
        public Address[] Addresses { get; private set; }

        private readonly List<Enrollment> _enrollments = new List<Enrollment>();
        public virtual IReadOnlyList<Enrollment> Enrollments => _enrollments.ToList();

        private Student() { }

        public Student(string email, string name, Address[] address)
            : this()
        {
            Email = email;
            EditPersonalInfo(name, address);
        }

        public void EditPersonalInfo(string name, Address[] address)
        {
            Name = name;
            Addresses = address;
        }

        public virtual void Enroll(Course course, Grade grade)
        {
            if (_enrollments.Count >= 2)
                throw new Exception("Cannot have more than 2 enrollments");

            if (_enrollments.Any(x => x.Course == course))
                throw new Exception(
                    $"Student '{Name}' already enrolled into course '{course.Name}'"
                );

            var enrollment = new Enrollment(this, course, grade);
            _enrollments.Add(enrollment);
        }
    }
}
