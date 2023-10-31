//�������� 1

//1)������� �������� MVC ��� ���������� ��������� �������. ���������� ������� ���� ��������� ��������������
//�� ����� HTTP cookie. ϳ��� �������������� ���������� ������� ���� ���������:

//2)������ �������, ���������� ��������� �����.
//����������� �� �������, �� �� �������.
//����� ���������� �� ����� ����������� ���� ��� �������. �� ��������� ��������������,
//���������� �� ������� ���� ��������� ����������� ������� ��������� �� ��������� �������.
//��� ��������� ������������ �� ������� ����� ��������������� �������� ��'���� � ���������� ���'�� ��� ���� ����� �� ������ ��������.

//1)Conect all services in program -
//2)Create controllers and models-
//3)Create registred view.Set res value in binding model-
//4)Create database-
//5)Connect database to project(if user was not registrate so create new user in table(Users)).-
//6)create sign in view and claims if user exist.-
//7)Redirect user to home page(adding page) where he may write a note-
//7.1Create view to add note and view to read note-
//8)Create a service to save note to database. 8.1) create table for note in database-
//9)Create reading page. user can read his note in this page. -
using AspLesson11.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AspLesson11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(options =>
            {
                options.LoginPath = "/account/signin";
            });
            builder.Services.AddScoped<IPasswordHasher,PasswordHasher>();
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            app.Run();
        }
    }
}