//using Microsoft.AspNetCore.Authentication.OAuth;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using System.ComponentModel.Design;
//using System.Security.Claims;
//using System.Text.Json.Serialization;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Hosting;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
//using Microsoft.OpenApi.Models;
//using LibraryApp.Controllers;
//using System;
//using LibraryApp.Data;

//namespace LibraryApp.Tests.E2E
//{
//    public class TestStartup
//    {
//        private readonly IConfigurationRoot _configuration;
//        private readonly IConfiguration configuration;

//        public TestStartup(IWebHostEnvironment hostEnv, IConfiguration configuration)
//        {
//            this.configuration = configuration;
//            _configuration = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
//        }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            //services.AddSingleton<ILoggerProvider>(new LoggerProvider(configuration));
//            //services.AddLogging();

//            // Deploy
//            string connString = "Server=postgres;User ID=postgres;Password=17009839;Port=5432;Database=tractor_plant;";
//            // Local
//            //string connString = "Server=localhost;User ID=postgres;Password=17009839;Port=5433;Database=tractor_plant;";

//            services.AddDbContext<DataContext>(options => options.UseNpgsql(connString));

//            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//            //        .AddCookie(options =>
//            //        {
//            //            options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
//            //            options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
//            //        });

//            services.AddTransient<IButtonsEventsService, ButtonsEventsService>();
//            services.AddTransient<IButtonsPostsService, ButtonsPostsService>();
//            services.AddTransient<IEventsService, EventsService>();
//            services.AddTransient<IEventsTypesService, EventsTypesService>();
//            services.AddTransient<IUsersService, UsersService>();

//            services.AddTransient<IButtonsEventsRepository, ButtonsEventsRepository>();
//            services.AddTransient<IButtonsPostsRepository, ButtonsPostsRepository>();
//            services.AddTransient<IEventsRepository, EventsRepository>();
//            services.AddTransient<IEventsTypesRepository, EventsTypesRepository>();
//            services.AddTransient<IUsersRepository, UsersRepository>();

//            services.AddControllersWithViews();

//            services.AddControllers()
//                .AddApplicationPart(typeof(ButtonsEventsController).Assembly)
//                .AddApplicationPart(typeof(ButtonsPostsController).Assembly)
//                .AddApplicationPart(typeof(EventsController).Assembly)
//                .AddApplicationPart(typeof(EventsTypesController).Assembly)
//                .AddApplicationPart(typeof(UsersController).Assembly)
//                .AddApplicationPart(typeof(AccountController).Assembly)
//                .AddJsonOptions(opts =>
//                {
//                    opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
//                });

//            // Регистрируйте Swagger-генератор
//            services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tractor plant API", Version = "v1" });
//                c.OperationFilter<RoleDescriptionOperationFilter>();

//            });

//            services.AddOptions();

//            // AutoMapper
//            services.AddAutoMapper(typeof(AutoMappingProfile));

//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseHttpsRedirection();
//            app.UseStaticFiles();
//            app.UseRouting();

//            //var loggerFactory = app.ApplicationServices.GetService<ILoggerFactory>();
//            var logger = loggerFactory.CreateLogger("Category");

//            logger.LogInformation("Application started.");

//            app.UseExceptionHandler(errorApp =>
//            {
//                errorApp.Run(async context =>
//                {
//                    context.Response.StatusCode = 500;
//                    context.Response.ContentType = "text/plain";

//                    var exceptionHandlerPathFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();
//                    var exception = exceptionHandlerPathFeature.Error;

//                    //logger.LogError(exception, $"Unhandled exception. Path: {exceptionHandlerPathFeature.Path}");

//                    await context.Response.WriteAsync("An error occurred while processing your request.");
//                });
//            });

//            app.Use(async (context, next) =>
//            {
//                var requestPath = context.Request.Path.Value;
//                var requestMethod = context.Request.Method;

//                logger.LogInformation($"Request received. Method: {requestMethod}, Path: {requestPath}");

//                await next.Invoke();

//                var responseStatusCode = context.Response.StatusCode;

//                //logger.LogInformation($"Request completed. Method: {requestMethod}, Path: {requestPath}, Status Code: {responseStatusCode}");
//            });

//            //loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logs"));

//            //app.UseAuthentication();
//            //app.UseAuthorization();

//            //app.UseEndpoints(endpoints =>
//            //{
//            //    endpoints.MapControllerRoute(
//            //        name: "default",
//            //        pattern: "{controller=Account}/{action=Logout}/{id?}");

//            //});

//            // Включите Swagger и SwaggerUI
//            app.UseSwagger();
//            app.UseSwaggerUI(c =>
//            {
//                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryApp");
//                c.RoutePrefix = "swagger"; // Настраивайте URL для доступа к SwaggerUI
//            });
//        }
//    }
//}