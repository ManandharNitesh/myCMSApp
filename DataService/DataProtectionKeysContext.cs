using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService
{
  public   class DataProtectionKeysContext :DbContext,IDataProtectionKeyContext
    {
        //Keys storage providers in Asp.Net Core

        public DataProtectionKeysContext(DbContextOptions<DataProtectionKeysContext> options)
            : base(options) { }
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

    }
}
