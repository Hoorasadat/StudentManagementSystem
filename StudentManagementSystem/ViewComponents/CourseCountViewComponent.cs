﻿using EnrollmentManagementSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.WEB.ViewComponents
{
    public class CourseCountViewComponent : ViewComponent
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public CourseCountViewComponent(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _enrollmentRepository.CourseEnrollmentCount();

            return View(result);
        }

    }
}