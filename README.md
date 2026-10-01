# Estruturas de Dados em C# 

> **Unidade Digital de Aprendizagem (UDA)** · PUC Minas   
> **Autor:** Prof. Kleber Jacques Ferreira de Souza  

---

## 📖 Apresentação

Bem-vindo ao repositório oficial da Unidade Digital de Aprendizagem de **Estruturas de Dados em C#**.

---

## 💻 Estrutura dos Projetos de Código em C#

Cada projeto pode ser compilado e executado diretamente via terminal utilizando o **.NET 10 SDK**:

```bash
# Projeto 1 — TADs Estáticas (Vetores e Array Circular)
cd projetos/Projeto1-TADs-Estaticas
dotnet run

# Projeto 2 — TADs Dinâmicas (Célula, Lista Simples, Pilha e Fila)
cd ../Projeto2-TADs-Dinamicas
dotnet run

# Projeto 3 — Lista Duplamente Encadeada (Célula Dupla, Sentinela e Inversão)
cd ../Projeto3-Lista-Duplamente-Encadeada
dotnet run

# Projeto 4 — Aplicação Prática Completa (Sistema da Clínica Médica)
cd ../Projeto4-Sistema-Clinica-Pratica
dotnet run
```

---

## 📊 Matriz Geral de Complexidade Algorítmica (Big-O)

| Operação | Vetor Contíguo (Array) | Lista Encadeada Simples | Lista Duplamente Encadeada | Fila Dinâmica | Pilha Dinâmica |
| :--- | :---: | :---: | :---: | :---: | :---: |
| **Acesso por Índice `[i]`** | $\mathbf{O(1)}$ | $O(n)$ | $O(n)$ | — | — |
| **Inserção no Início** | $O(n)$ | $\mathbf{O(1)}$ | $\mathbf{O(1)}$ | — | $\mathbf{O(1)}$ |
| **Inserção no Fim** | $\mathbf{O(1)}$ (se houver espaço) | $\mathbf{O(1)}$ (com ponteiro `ultimo`) | $\mathbf{O(1)}$ | $\mathbf{O(1)}$ | — |
| **Remoção no Início** | $O(n)$ | $\mathbf{O(1)}$ | $\mathbf{O(1)}$ | $\mathbf{O(1)}$ | $\mathbf{O(1)}$ |
| **Remoção no Fim** | $\mathbf{O(1)}$ | $O(n)$ | $\mathbf{O(1)}$ | — | — |
| **Remoção de Nó Conhecido**| $O(n)$ | $O(n)$ | $\mathbf{O(1)}$ | — | — |

---

## 📚 Referências Bibliográficas

- **CORMEN, Thomas H. et al.** *Algoritmos: teoria e prática*. 3. ed. Rio de Janeiro: Elsevier, 2012.
- **DROZDEK, Adam.** *Estrutura de Dados e Algoritmos em C++*. 1. ed. São Paulo: Cengage Learning, 2016.
- **GOODRICH, Michael T.; TAMASSIA, Roberto; GOLDWASSER, Michael H.** *Estruturas de Dados e Algoritmos em Java*. 6. ed. Porto Alegre: Bookman, 2015.
- **SEDGEWICK, Robert; WAYNE, Kevin.** *Algorithms*. 4. ed. Upper Saddle River: Addison-Wesley, 2011.
- **ZIVIANI, Nivio.** *Projeto de algoritmos com implementações em Pascal e C*. 3. ed. São Paulo: Cengage Learning, 2011.

---

*PUC Minas · Unidade Digital de Aprendizagem · ICEI*
