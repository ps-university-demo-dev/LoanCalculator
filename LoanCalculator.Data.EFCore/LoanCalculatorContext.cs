using LoanCalculator.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanCalculator.Data.EFCore
{
    public class LoanCalculatorContext : DbContext
    {

        public LoanCalculatorContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<LoanRate> LoanRates { get; set; }

        public DbSet<LoanTerm> LoanTerms { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<LoanApplicationResult> LoanApplicationResults { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ConfigureLoanTerm(modelBuilder);
            this.ConfigureLoanRate(modelBuilder);
            this.ConfigurePerson(modelBuilder);
            this.ConfigureLoanApplicationResult(modelBuilder);
            this.SeedData(modelBuilder);
        }


        private void ConfigureLoanTerm(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanTerm>()
                .ToTable("LoanTerms")
                .HasKey(lt => lt.Years);
        }

        private void ConfigureLoanRate(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanRate>()
                .ToTable("LoanRates")
                .HasKey(lt => lt.LoanRateId);
        }


        private void ConfigurePerson(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .ToTable("Persons")
                .HasKey(lt => lt.PersonId);
        }


        private void ConfigureLoanApplicationResult(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanApplicationResult>()
                .ToTable("LoanApplicationResults")
                .HasKey(r => r.ResultId);
        }


        private void SeedData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<LoanTerm>().HasData(
                new LoanTerm() { Name = "10 Year", Years = 10 },
                new LoanTerm() { Name = "15 Year", Years = 15 },
                new LoanTerm() { Name = "25 Year", Years = 20 },
                new LoanTerm() { Name = "30 Year", Years = 30 }
            );

            modelBuilder.Entity<LoanRate>().HasData(
                new LoanRate() { LoanRateId = 1, LowerCreditScore = 50, UpperCreditScore = 59, InterestRate = 8.5 },
                new LoanRate() { LoanRateId = 2, LowerCreditScore = 60, UpperCreditScore = 69, InterestRate = 7.5 },
                new LoanRate() { LoanRateId = 3, LowerCreditScore = 70, UpperCreditScore = 79, InterestRate = 6.25 },
                new LoanRate() { LoanRateId = 4, LowerCreditScore = 80, UpperCreditScore = 89, InterestRate = 5.25 },
                new LoanRate() { LoanRateId = 5, LowerCreditScore = 90, UpperCreditScore = 100, InterestRate = 4.0 }
            );

            modelBuilder.Entity<Person>().HasData(
                new Person() { PersonId = 1, FirstName = "Andrew", LastName = "Smith", CreditScore = 89, AnnualIncome = 100000 },
                new Person() { PersonId = 2, FirstName = "Maggie", LastName = "Cohen", CreditScore = 72, AnnualIncome = 80000 },
                new Person() { PersonId = 3, FirstName = "Bryan", LastName = "Boyd", CreditScore = 44, AnnualIncome = 55000 },
                new Person() { PersonId = 4, FirstName = "Martha", LastName = "Fletcher", CreditScore = 87, AnnualIncome = 125000 },
                new Person() { PersonId = 5, FirstName = "Stephen", LastName = "Wright", CreditScore = 65, AnnualIncome = 75000 },
                new Person() { PersonId = 6, FirstName = "Marie", LastName = "Thomas", CreditScore = 58, AnnualIncome = 80000 }
            );
        }

    }
}
