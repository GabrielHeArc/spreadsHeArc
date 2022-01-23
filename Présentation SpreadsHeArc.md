---
title: SpreadsHeArc
tags: WPF, C#
type: slide 
slideOptions:
  theme: 'Solarized'
  transition: 'slide'   
---

# Présentation SpreadsHeArc

###### par Gabriel Fasano

Note: Présentation de mon projet, réalisé en groupe avec moi-même

---

## Problèmatique

- Feuille Excel : configuration des formules :sleeping:
- Visualisation des données : 
Ca passe, ça passe pas ? :confused:

Note: "JE"; Constatation : Adaptation du fichier excel existant avec nouveaux modules et branches, adaptation des calculs, etc.
Ajout de couleur pour rendre plus lisible => adapté les contraintes

---

## Buts

- Calculateur flexible  mais spécialisé pour moyennes de branches et de modules

Note: Même si Excel marche très bien, outil plus spécialisé avec affichage plus clair

---

## Fonctionnalités

- Ajouter des modules
- Ajouter des branches à des modules
- Ajouter des notes aux branches
- Mise a jour automatique des moyennes
- Visualiser les moyennes de branches et de modules
- Couleurs selon critères de réussite

Note: Fonctionnalités de base; 
Donc on doit pouvoir faire ces actions et visualiser changements immédiatements

---

## Techno/Language

- WPF
- C#

---

## Objectifs
 
----

### Objectifs primaires

- Ajouter des modules
- Ajouter des branches à des modules
- Ajouter des notes aux branches
- Visualiser les moyennes de branches et de modules

Note: Identique aux fonctionnalités

----

### Objectifs secondaires

- Persistences des données :
    - Sauvegarde des données (BDD)
    - Export des données en JSON :writing_hand: 
    - Import des données en JSON

Note: Pour la persistence des données, chargement et export

---

## Démo

:computer: 

---

## Développement

---

### Architecture MVVM

Note: Utilisation de l'architecture MVVM

----

#### Models

```mermaid
classDiagram
    Model <|-- Branch
    Model <|-- Module
    Model <|-- Rating
    INotifyPropertyChanged <|-- Model
    
    class Model {
    + <<event>> PropertyChangedEventHandler PropertyChanged
    + void RaisePropertyChanged(string property)
    }
    
    class Branch{
    - string _nameBranch
    - int _weightBranch
    - float _averageBranch
    - Module _module
    - ObservableCollection<Rate> _listRate
    
    <<property>> + string NameBranch
    <<property>> + int WeightBranch
    <<property>> + float AverageBranch
    <<property>> + ObservableCollection<Rate> ListRate
    <<property>> + Module Module
    
    + Branch(string name, int weight, Module module)
    + void ProcessAverage()
    }

    class Module{
    - string _nameModule
    - float _averageModule
    - ObservableCollection<Branch> _listBranch
    <<property>> + string NameModule
    <<property>> + float AverageModule
    <<property>> + ObservableCollection<Branch> ListBranch
    
    + Module(string name)
    + void ProcessAverage()
    }
    
    class Rating{
    - float _mark
    - int _weightMark
    <<property>> + float Mark
    <<property>> + int WeightMark
    
    + Rating(float mark, int weightMark)
    }
```

Note: Pas le plus intéressant; Tous les modèles héritent de Model, qui implémente INotifyPropertyChanged pour réagir aux changements dans les données.

----

#### ViewModels

```mermaid
classDiagram
    ViewModel <|-- BranchViewModel
    ViewModel <|-- ModuleViewModel
    INotifyPropertyChanged <|-- ViewModel

    class ViewModel{
        + <<event>> PropertyChangedEventHandler PropertyChanged
        # void RaisePropertyChanged(string property)
    }
    
    class BranchViewModel{
    - List<Branch> _listBranches
    - static BranchViewModel _instance
    
    <<property>> + List<Branch> ListBranches
    
    - BranchViewModel()
    - static BranchViewModel GetInstance()
    + void AddBranch(string name, int weight, Module module)
    + void AddRate(Branch branch, Raing rate)
    }
    
    class ModuleViewModel{
    - ObservableCollection<Module> _listModules
    - static ModuleViewModel _instance
    
    <<property>> + ObservableCollection<Module> ListModules
    
    
    - ModuleViewModel()
    - static ModuleViewModel GetInstance()
    + void AddModule(string name)
    }
    
```

Note: Les viewModel héritent de ViewModel qui implémente INotifyPropertyChanged. Les ViewModel sont des singleton. Nécessaire car besoin de référencer les instances de branche et de modules et garder des listes.

----

#### Views

```mermaid
classDiagram

    Window <|-- AddBranchWindow
    Window <|-- AddModuleWindow
    Window <|-- AddRatingWindow
    Window <|-- MainWindow
    
    class AddBranchWindow {
    - string _newBranchName
    - int _newBranchWeight
    - Module _module
    
    <<property>> + string NewBranchName
    <<property>> + int NewBranchWeight
    <<property>> + Module Module
    
    + AddBranchWindow()
    - void okButton_Click(object sender, RoutedEventArgs e)
    - void list_modules_SelectionChanged(object sender, SelectionChangedEventArgs e)
    }
    
    class AddModuleWindow {
    - string _newModuleName
    <<property>> + string NewModuleName
    
    - void okButton_Click(object sender, RoutedEventArgs e)
    + AddModuleWindow()
    }
    
    class AddRatingWindow {
    - Branch _branch
    - float _newMark
    - int _newMarkWeight
    
    <<property>> + Branch Branch
    <<property>> + float NewMark
    <<property>> + int NewMarkWeight
    
    - void okButton_Click(object sender, RoutedEventArgs e)
    - void list_branches_SelectionChanged(object sender, electionChangedEventArgs e)
    + AddRatingWindow()
    }
        
    class MainWindow {
    - void MenuItem_Click_Add_Module(object sender, RoutedEventArgs e)
    - void MenuItem_Click_Add_Branch(object sender, RoutedEventArgs e)
    - void MenuItem_Click_Add_Rate(object sender, RoutedEventArgs e)
    + MainWindow()
    }
```

Note: Evidemment code XAML, ici que code behind; Peu visible, slide suivante, pas très intéressant, passage rapide ...

----

##### MainWindow

```mermaid
classDiagram    
    class MainWindow {
    - void MenuItem_Click_Add_Module(object sender, RoutedEventArgs e)
    - void MenuItem_Click_Add_Branch(object sender, RoutedEventArgs e)
    - void MenuItem_Click_Add_Rating(object sender, RoutedEventArgs e)
    + MainWindow()
    }
```

![](https://i.imgur.com/01zI08G.png)


Note: Evénements dans la barre de menu; pas grid; stackpanel imbriqué

----


##### AddModuleWindow

```mermaid
classDiagram

    class AddModuleWindow {
    - string _newModuleName
    <<property>> + string NewModuleName
    
    - void okButton_Click(object sender, RoutedEventArgs e)
    + AddModuleWindow()
    }
```

![](https://i.imgur.com/c6LgkF9.png)

----

##### AddBranchWindow

```mermaid
classDiagram
 class AddBranchWindow {
    - string _newBranchName
    - int _newBranchWeight
    - Module _module
    
    <<property>> + string NewBranchName
    <<property>> + int NewBranchWeight
    <<property>> + Module Module
    
    + AddBranchWindow()
    - void okButton_Click(object sender, RoutedEventArgs e)
    - void list_modules_SelectionChanged(object sender, SelectionChangedEventArgs e)
    }
```

![](https://i.imgur.com/HBBJUhO.png)


Note: Nom branche, poids, nom module

----

##### AddRatingWindow

```mermaid
classDiagram

    class AddRatingWindow {
    - Branch _branch
    - float _newMark
    - int _newMarkWeight
    
    <<property>> + Branch Branch
    <<property>> + float NewMark
    <<property>> + int NewMarkWeight
    
    - void okButton_Click(object sender, RoutedEventArgs e)
    - void list_branches_SelectionChanged(object sender, electionChangedEventArgs e)
    + AddRatingWindow()
    }
```

![](https://i.imgur.com/uOR7n71.png)

Note: Mark = une note; Rating = poids + note; 
Chiffre à virgule non reconnu sur cette ordinateur. Poids pas en dur

---

### Binding

- Liste déroulante des modules
![](https://i.imgur.com/mGVysvO.png)
- Liste déroulante des branches
![](https://i.imgur.com/hNO18nY.png)
- Mise à jour des branches/modules/moyennes


---

## Améliorations

- Design
- Exportation des données
- Importation des données


---

## Problème connu

- Nombres à virgule

---

## Conclusion

- Objectifs principaux :heavy_check_mark: 
- Délais respectés :heavy_check_mark:
- Besoin de persistance sinon inutile

---

## Merci de votre attention
:sleeping:

---

# Questions :question: 