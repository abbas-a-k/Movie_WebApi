using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IAdminDirectorsRepository
    {
        Task<Directors> CreateDirectorForAdmin(Directors directorModel);
        Task<Directors> DeleteDirectorsForAdmin(int directorId);
        Task<bool> DirectorsExists(int directorId);
    }
}