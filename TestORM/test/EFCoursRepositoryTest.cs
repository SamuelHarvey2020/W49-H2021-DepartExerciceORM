﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestORMCodeFirst.Entities;
using TestORMCodeFirst.Persistence;
using Xunit;

namespace TestORMCodeFirst.DAL
{
    public class EFCoursRepositoryTest
    {

        private EFCoursRepository repoCours;
        private EFInscCoursRepository repoInscriptions;
        private void SetUp()
        {
            // Initialiser les objets nécessaires aux tests
            var builder = new DbContextOptionsBuilder<CegepContext>();
            builder.UseInMemoryDatabase(databaseName: "testCours_db");   // Database en mémoire
            var contexte = new CegepContext(builder.Options);
            repoCours = new EFCoursRepository(contexte);
            repoInscriptions = new EFInscCoursRepository(contexte);
        }


        [Fact]
        public void CreerCours()
        {
            // Arrange
            SetUp();
            Cours cours = new Cours
            {
                CodeCours = "420-W49-SF",
                NomCours = "BD2",

            };

            // Act
            repoCours.AjouterCours(cours);

            // Assert
            var result = this.repoCours.ObtenirListeCours();
            Assert.Single(result);
            Assert.Same(cours, result.First());
        }
    }
}