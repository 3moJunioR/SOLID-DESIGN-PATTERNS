# Design Patterns 🧩

**Design Patterns** are reusable solutions to common problems that repeatedly occur in software design.
They are not code you copy — they are **ideas or templates** you apply to your specific problem.

---

## Why Use Design Patterns?

- Makes your code easier to understand and maintain
- Gives your team a shared vocabulary ("we used a Facade here")
- Solves well-known problems with proven approaches
- Helps you apply SOLID principles

---

## The Three Categories

```
Design Patterns
├── Creational  →  How you create objects
├── Structural  →  How you organize relationships between classes
└── Behavioral  →  How classes communicate with each other
```

---

## Creational Patterns

> **The question they answer:** How do I create objects in a smart and flexible way?

| Pattern | What it solves |
|---|---|
| **Singleton** | Ensures a class has **only one instance** throughout the application's lifetime — e.g. a database connection |
| **Factory** | Instead of calling `new` directly, you delegate object creation to a **dedicated class** that decides which object to instantiate |

---

## Structural Patterns

> **The question they answer:** How do I organize and connect classes properly?

| Pattern | What it solves |
|---|---|
| **Facade** | Provides a **simple interface** that hides the complexity of multiple subsystems — the client talks to one thing only |
| **Adapter** | Makes **two incompatible classes work together** without modifying either — like a power plug adapter |
| **Decorator** | Adds **new behavior to an object** at runtime without creating a subclass or modifying the original class |

---

## Behavioral Patterns

> **The question they answer:** How do classes communicate and share responsibilities?

| Pattern | What it solves |
|---|---|
| **Strategy** | Lets you **swap algorithms at runtime** without changing the code — e.g. switching payment methods |
| **Observer** | When one object changes, all **subscribed objects are notified automatically** — e.g. a notification system |

---

## Quick Summary

```
Need to control how objects are created?         → Creational (Singleton, Factory)
Need to organize relationships between classes?  → Structural (Facade, Adapter, Decorator)
Need to organize communication between classes?  → Behavioral (Strategy, Observer)
```
