using ChatApp.Core.Command;
using ChatApp.Domain.Models;
using ChatApp.Extensions;
using ChatApp.Hubs;
using ChatApp.Infastructure.Persistence;
using ChatApp.Infastructure.Producer;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace ChatApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCorsExtension();
            services.AddSignalR();
            services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IRequestHandler<CreateChatCommand, Chat>, CreateChatCommandHandler>();
            services.AddSingleton<IChatSender, ChatSender>();
            services.AddSwaggerExtension();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}
