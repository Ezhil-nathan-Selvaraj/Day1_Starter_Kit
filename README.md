# Day 1 - Director Upskilling: TFS → Git + .NET 8 Foundation
Ezhilnathan S. | Target: Director Healthcare Tech

## TODAY'S 60-MIN PLAN (Let's start now)

### Task 1: Git Setup (15 min)
1. Install Git: https://git-scm.com/download/win
2. Configure:
   git config --global user.name "Ezhilnathan S"
   git config --global user.email "ezhilnathan.selvaraj@outlook.com"
3. Create GitHub account (if not): github.com
4. Create new repo: wcf-to-rest-migration (Public)
   - DO NOT init with README (we will push)

### Task 2: Create Local Migration Project (20 min)
- This kit contains a sample WCF-style service (PatientOnLine legacy style)
- We will migrate it to Git + convert to REST

Structure:
- /Legacy_WCF_Sample (your old style)
- /Modern_REST_API (.NET 8 target - we will create tomorrow)

### Task 3: First Git Push (10 min)
cd Legacy_WCF_Sample
git init
git add .
git commit -m "Initial: Legacy WCF sample from Fresenius PD domain"
git branch -M main
git remote add origin https://github.com/<your-username>/wcf-to-rest-migration.git
git push -u origin main

### Task 4: Setup Branching Strategy (15 min)
- Create branch: feature/migrate-to-rest
git checkout -b feature/migrate-to-rest
- Create PR template, .gitignore for .NET

DONE = You have completed Lab 1 - Part 1. Commit proof in tracker.

Tomorrow: Convert WCF contract to ASP.NET Core 8 minimal API.

---
Your Advantage: You already manage 85+ across 5 countries - this lab gives you the story:
"We migrated legacy WCF from TFS to Git + Azure DevOps, enabling trunk-based delivery"
This is what Director interviewers want to hear.
