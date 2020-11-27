﻿using DemoApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DemoApi.Models
{
    /// <summary>
    /// DBコンテスト定義クラス
    /// </summary>
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<TUser> TUser { get; set; }
    }
}
