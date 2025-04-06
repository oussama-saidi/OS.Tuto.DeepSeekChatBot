[Créer un Chatbot avec DeepSeek et .NET 9 : Tutoriel Complet](https://oussamasaidi.com/creer-un-chatbot-avec-deepseek-et-net-9-tutoriel-complet/)

# DeepSeek ChatBot avec .NET 9

![.NET Version](https://img.shields.io/badge/.NET-9.0-blue)
![License](https://img.shields.io/badge/License-MIT-green)

Un chatbot intelligent utilisant l'API DeepSeek, construit avec ASP.NET Core 9. Ce projet démontre l'intégration d'IA conversationnelle dans une application web moderne.

## Demo Vidéo

Voir le chatbot en action:

[![DeepSeek ChatBot Demo](https://img.youtube.com/vi/F0ORjUb7pVA/0.jpg)](https://www.youtube.com/watch?v=F0ORjUb7pVA)

## Fonctionnalités

- 💬 Conversation interactive avec l'IA DeepSeek
- 🧠 Maintien du contexte de la discussion
- ⚡ Interface simple et réactive
- 🔄 Possibilité d'extension pour le streaming (optionnel)
- 🔒 Sécurité intégrée (protection des clés API)

## Prérequis

- [SDK .NET 9](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 ou VS Code
- Compte [DeepSeek](https://deepseek.com) pour obtenir une clé API

## Installation

1. Cloner le dépôt :
```bash
git@github.com:oussama-saidi/OS.Tuto.DeepSeekChatBot.git
```
cd DeepSeekChatBot
Configurer la clé API :
```json
// Dans appsettings.json
{
  "DeepSeek": {
    "ApiKey": "votre-clé-api-ici"
  }
}
```

    Lancer l'application :
```bash 
dotnet run
```

Structure du Projet
```bash

DeepSeekChatBot/
├── Pages/
│   └── Chat.cshtml        # Interface de chat
├── Models/
│   ├── ChatMessage.cs     # Modèle de message
│   └── ChatRequest.cs     # Modèle de requête API
├── Services/
│   └── DeepSeekService.cs # Service d'intégration API
└── Program.cs             # Configuration de l'app
```
Personnalisation
Paramètres modifiables :

Temperature (0-2) : Contrôle la créativité des réponses

MaxTokens : Limite la longueur des réponses

Modèle : deepseek-chat par défaut

Exemple dans Models/ChatRequest.cs :
```csharp
public double Temperature { get; set; } = 0.7;  // Valeur entre 0 (précis) et 2 (créatif)
public int MaxTokens { get; set; } = 2000;      // Longueur maximale des réponses
```
Déploiement
Options recommandées :

Azure App Service :

```bash
az webapp up --sku F1 --name votre-nom-app
```
Docker :

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0
COPY ./publish /app
WORKDIR /app
ENTRYPOINT ["dotnet", "DeepSeekChatBot.dll"]
```
Contributions
Les contributions sont les bienvenues ! Étapes :

    Forker le projet

    Créer une branche (git checkout -b feature/amelioration)

    Committer vos changements (git commit -m 'Ajout d'une fonctionnalité')

    Pousser vers la branche (git push origin feature/amelioration)

    Ouvrir une Pull Request

Licence

Distribué sous licence MIT. Voir LICENSE pour plus d'informations.
Auteur

[Oussama SAIDI] - oussama.saidisbz@gmail.com
<div align="center"> <sub>Développé avec ❤️ et .NET 9</sub> </div>
