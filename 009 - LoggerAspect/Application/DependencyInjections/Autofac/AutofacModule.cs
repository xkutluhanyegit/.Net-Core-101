
using Application.Interfaces;
using Application.Mapping;
using Application.Services;
using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Castle.DynamicProxy;
using Domain.CrossCutting.Logging;
using Domain.Interfaces.UnitOfWork;
using Domain.Utilities.Interceptors;
using Infrastructure.Contexts.EntityFramework;
using Infrastructure.Identity.Hasher;
using Infrastructure.Identity.Jwt;
using Infrastructure.Repositories.ClaimRepository;
using Infrastructure.Repositories.RoleRepository;
using Infrastructure.Repositories.UserRepository;
using Infrastructure.Repositories.UserRoleRepository;
using Infrastructure.UnitOfWork;

namespace Application.DependencyInjections.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Application DI
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerLifetimeScope();
            builder.RegisterType<UserRoleService>().As<IUserRoleService>().InstancePerLifetimeScope();
            builder.RegisterType<ClaimService>().As<IClaimService>().InstancePerLifetimeScope();
            


            //Infrastructure DI
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRoleRepository>().As<IUserRoleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ClaimRepository>().As<IClaimRepository>().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.RegisterType<PasswordHasher>().As<IPasswordHasher>().InstancePerLifetimeScope();
            builder.RegisterType<TokenService>().As<ITokenService>().InstancePerLifetimeScope();
            

            //DbContext DI
            builder.RegisterType<AppDbContext>().AsSelf().InstancePerLifetimeScope();

            //AutoMapper
            builder.Register(config => new MapperConfiguration( c => {
                //Add Mapper Profile
                c.AddProfile(new RoleProfile());
                c.AddProfile(new UserProfile());
                c.AddProfile(new UserRoleProfile());
                c.AddProfile(new ClaimProfile());
            })).AsSelf().SingleInstance();

            builder.Register( ctx => ctx.Resolve<MapperConfiguration>().CreateMapper() ).As<IMapper>().InstancePerLifetimeScope();



            builder.RegisterType<SerilogLoggerService>().As<ILoggerService>().SingleInstance();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}