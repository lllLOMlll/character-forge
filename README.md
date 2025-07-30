# 🧙‍♂️ CharacterForge

**CharacterForge** est une application web full-stack permettant de créer, gérer et exporter des personnages pour des jeux de rôle (RPG fantasy ou science-fiction).

Ce projet est construit avec :
- **ASP.NET Core 9 (Web API)** — pour le backend
- **Angular** — pour le frontend
- **TypeScript, Bootstrap** — pour une interface dynamique et agréable

---

## 📦 Fonctionnalités

✅ Création de personnages avec :
- Nom, race, classe
- Caractéristiques de base (force, dextérité, etc.)
- Objets magiques et effets associés

✅ Gestion :
- Ajout / modification / suppression de personnages
- Liaison entre personnages ↔ objets ↔ effets
- Interface dynamique avec formulaires complexes

✅ Export :
- Génération d'une fiche de personnage en **PDF ou JSON**

---

## 🏗️ Architecture du projet

```text
CharacterForge/
├── CharacterForgeApi/        # Backend ASP.NET Core 9 (Web API)
├── CharacterForgeUI/         # Frontend Angular (CLI)
├── .gitignore
├── README.md
