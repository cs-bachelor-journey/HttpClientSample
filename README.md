# HttpClientSample

Application console C# (.NET 10) qui consomme l’API REST publique `JSONPlaceholder` avec `HttpClient`.

## Objectif

Ce projet montre comment exécuter les opérations CRUD de base sur la ressource `todos` :

- `GET /todos`
- `GET /todos/{id}`
- `POST /todos`
- `PUT /todos/{id}`
- `DELETE /todos/{id}`

> L’API `JSONPlaceholder` est une API de test.  
> Les opérations `POST`, `PUT` et `DELETE` retournent des réponses simulées (pas de vraie persistance côté serveur).

---

## Stack technique

- .NET `10.0`
- C#
- `HttpClient`
- `Newtonsoft.Json`

Package NuGet utilisés :

- `Newtonsoft.Json` (`13.0.4`)
- `Microsoft.AspNet.WebApi.Client` (`6.0.0`)

---

## Structure du projet

- `Program.cs`  
  Point d’entrée console. Exécute les appels REST dans l’ordre : GET all, GET by id, POST, PUT, DELETE.
- `RestApiQueries.cs`  
  Encapsule les appels HTTP.
  - Méthodes async : `GetTodosAsync`, `GetTodoAsync`, `AddTodoAsync`, `CompleteTodoAsync`, `RemoveTodoAsync`
  - Wrappers sync : `GetTodos`, `GetTodo`, `AddTodo`, `CompleteTodo`, `DeleteTodo`
- `Models/Todo.cs`  
  Modèle `Todo` mappé avec attributs JSON (`userId`, `id`, `title`, `completed`).

---

## Pré-requis

- SDK .NET 10 installé
- Connexion Internet (API externe : `https://jsonplaceholder.typicode.com/`)

Vérifier la version :

`dotnet --version`

---

## Installation et exécution

1. Cloner le repo
2. Ouvrir le dossier du projet (`HttpClientSample`)
3. Restaurer les dépendances
4. Lancer l’application

Commandes :

`dotnet restore`  
`dotnet run`

---

## Comportement à l’exécution

Le programme exécute automatiquement :

1. `GET /todos` et affiche la liste (20 premiers éléments)
2. `GET /todos/1`
3. `POST /todos` avec un `Todo` de test
4. `PUT /todos/1` avec un `Todo` modifié
5. `DELETE /todos/1`

Exemple de sortie (résumé) :

- `GET /todos -> 200 éléments`
- `GET /todos/1 -> #1 | ...`
- `POST /todos -> OK`
- `PUT /todos/1 -> OK`
- `DELETE /todos/1 -> OK`

---

## Détails endpoint

Base URL configurée dans `RestApiQueries` :

`https://jsonplaceholder.typicode.com/`

Endpoint utilisé dans `Program.cs` :

`todos`

URL complètes appelées :

- `https://jsonplaceholder.typicode.com/todos`
- `https://jsonplaceholder.typicode.com/todos/1`

---

## Personnalisation rapide

### Changer l’endpoint
Dans `Program.cs`, modifier :

`const string endpoint = "todos";`

### Changer l’API cible
Dans le constructeur de `RestApiQueries`, modifier :

`_client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");`

---

## Limitations connues

- API de démonstration : pas de persistance réelle sur `POST/PUT/DELETE`.
- Les méthodes sync utilisent `Task.Run(...).Wait()` pour encapsuler les versions async.
- Peu de validation métier (projet orienté démonstration HTTP).

---

## Vérification rapide en cas de problème

- Erreur réseau : vérifier l’accès Internet.
- Erreur package : relancer `dotnet restore`.
- Erreur build : vérifier que le SDK `.NET 10` est bien installé.

---

## Licence

Projet pédagogique / démonstration.