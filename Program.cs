using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Linq;
using SqlKataStudy.Models;
using SqlKataStudy.Models.Enums;
//
using SqlKata.Compilers;
using SqlKata.Execution;

namespace SqlKataStudy
{
    class Program
    {
        static void Main(string[] args)
        {

            var category = InsertCategory();
            var author = InsertAuthor();
            var career = InsertCareer();
            var course = InsertCourse(author, category);
            var careerItem = InsertCareerItem(course, career);

            Console.WriteLine($"GetCareerFromAJoinCount: {GetCareerFromAJoin().Count()}");
            Console.WriteLine($"GetCategoryById: {GetCategoryById(category.CategoryId).Title}");
            Console.WriteLine($"GetAllCategories: {GetAllCategories().Count()}");
            category.ChangeTitle("ABCDEFGH");
            Console.WriteLine($"UpdateCategoryCount: {UpdateCategory(category.CategoryId, category)}");
            Console.WriteLine($"UpdateCategoryTitleCount: {UpdateCategoryTitle(category.CategoryId, "ZZZZZZZZZZZZZZ")}");

            var categoryToDelete = InsertCategory();
            Console.WriteLine($"DeleteCategoryCount: {DeleteCategory(categoryToDelete.CategoryId)}");

            // INSERT

            static Category InsertCategory()
            {
                using var db = GetFactory();
                var category = new Category(
                    "Category",
                    "Url",
                    "Summary",
                    1,
                    "Description",
                    true
                );
                db.Query("Category").Insert(category);
                return category;
            }

            static Career InsertCareer()
            {
                using var db = GetFactory();
                var career = new Career(
                    "Career",
                    "Summary",
                    "Url",
                    120,
                    true,
                    true,
                    "tag;example;other"
                );
                db.Query("Career").Insert(career);
                return career;
            }

            static Author InsertAuthor()
            {
                using var db = GetFactory();
                var author = new Author(
                    "Author",
                    "Title",
                    "Image",
                    "Bio",
                    "Url",
                    "Email",
                    EAuthorType.Novelist
                );
                db.Query("Author").Insert(author);
                return author;
            }

            static Course InsertCourse(Author author, Category category)
            {
                using var db = GetFactory();
                var course = new Course(
                    "Title",
                    "Tag",
                    "Summary",
                    "Url",
                    ECourseLevel.Advanced,
                    120,
                    DateTime.Now,
                    DateTime.Now,
                    true,
                    false,
                    true,
                    author.AuthorId,
                    category.CategoryId,
                    "tags"
                );
                db.Query("Course").Insert(course);
                return course;
            }

            static CareerItem InsertCareerItem(Course course, Career career)
            {
                using var db = GetFactory();
                var careerItem = new CareerItem(
                        "Title",
                        "Description",
                        1,
                        course.CourseId,
                        career.CareerId
                    );
                db.Query("CareerItem").Insert(careerItem);
                return careerItem;
            }

            // GET 

            static Category GetCategoryById(Guid id)
            {
                using var db = GetFactory();
                var result = db
                    .Query("Category")
                    .Where("CategoryId", id.ToString());
                return result.Get<Category>().FirstOrDefault();
            }

            static IEnumerable<Category> GetAllCategories()
            {
                using var db = GetFactory();
                var result = db
                    .Query("Category");
                return result.Get<Category>();
            }

            static IEnumerable<dynamic> GetCareerFromAJoin()
            {
                using var db = GetFactory();
                var result = db
                    .Query("Career")
                    .Select("Career.Title as Career", "CareerItem.Title as CareerItem", "Course.Title as Course")
                    .Join("CareerItem", join => join.On("Career.CareerId", "CareerItem.CareerId"))
                    .Join("Course", join => join.On("Course.CourseId", "CareerItem.CourseId"));
                return result.Get<dynamic>();
            }

            // UPDATE

            static int UpdateCategory(Guid id, Category category)
            {
                using var db = GetFactory();
                return db
                    .Query("Category")
                    .Where("CategoryId", id.ToString())
                    .Update(category);
            }

            static int UpdateCategoryTitle(Guid id, string title)
            {
                using var db = GetFactory();
                return db
                    .Query("Category")
                    .Where("CategoryId", id.ToString())
                    .Update(new
                    {
                        Title = title
                    });
            }

            // DELETE

            static int DeleteCategory(Guid id)
            {
                using var db = GetFactory();
                return db
                    .Query("Category")
                    .Where("CategoryId", id.ToString())
                    .Delete();
            }

            static QueryFactory GetFactory()
            {
                var connection = new SqlConnection(@"Data Source=desktop-vf2hide\sqlexpress;Initial Catalog=SqlKata;Integrated Security=True;Connect Timeout=30");
                var compiler = new SqlServerCompiler();
                return new QueryFactory(connection, compiler);
            }

        }
    }
}


