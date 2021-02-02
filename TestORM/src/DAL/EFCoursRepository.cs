using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestORMCodeFirst.Entities;
using TestORMCodeFirst.Persistence;

namespace TestORMCodeFirst.DAL
{
    public class EFCoursRepository
    {
        private CegepContext contexte;

        public EFCoursRepository(CegepContext ctx)
        {
            contexte = ctx;
        }

        public void AjouterCours(Cours cours)
        {
            contexte.Cours.Add(cours);
            contexte.SaveChanges();
        }

        List<Cours> ObtenirListeCours()
        {
            return contexte.Cours.toList;   
        }

        void MettreAJourNoteFinale(short etudiantID, string cours, string session, short note)
        {
            InscriptionCours insc = contexte.InscCours.Find(etudiantID, cours, session);
            insc.NoteFinale = note;
            contexte.SaveChanges();
        }

        double ObtenirPourUneClasseLaMoyenne(string cours, string session)
        {
            List<InscriptionCours> inscCoursListe = contexte.InscCours.Where(insc => insc.CodeSession == session && insc.CodeCours == cours);
            double somme = 0;

            foreach(inscCours.NoteFinale notes in inscCoursListe){
                somme += notes;
            }
            double moyenne = somme / inscCoursListe.Count();

            return moyenne;
        }

        int ObtenirPourUneClasseNombreEchecs(string cours, string session)
        {
            List<InscriptionCours> inscCoursListe = contexte.InscCours.Where(insc => insc.CodeSession == session && insc.CodeCours == cours);

            int echecs = 0;

            foreach (inscCours.NoteFinale notes in inscCoursListe)
            {
                if(notes < 60)
                {
                    echecs++;
                }
            }

            return echecs;
        }
    }
}