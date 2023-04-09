namespace CEM.Repositories;

using CEM.Models;
using System.Collections.Generic;
public interface ICategoryRepository
{
    void createNewCategory(string name);
    List<string> getAllCategoriesNames();
}