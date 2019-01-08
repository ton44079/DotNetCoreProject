using System;
using ArcAPI.Repository.Implements;
using ArcAPI.Service.Interfaces;

namespace ArcAPI.Service.Implements
{
    public class CompanyService : ICompanyService
    {
        public CompanyService()
        {
        }

        public string GetCompanyName()
        {

            return "Test Data";
        }
    }
}
