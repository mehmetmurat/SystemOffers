using Autofac;
using Autofac.Core;
using Microsoft.EntityFrameworkCore;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusiness.DependencyResolvers.AutoFac
{
    public class AutoFacBusinessModul : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UsersService>().As<IUsersService>();
            builder.RegisterType<EFUsersDal>().As<IUsersDal>();

            builder.RegisterType<OfferSystemContext>().AsSelf().As<DbContext>().InstancePerLifetimeScope();
        }
    }
}
