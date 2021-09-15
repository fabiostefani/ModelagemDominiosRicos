# Modelagem de Domínios Ricos
Projeto para anotações e prática do curso de Modelagem de Domínios Ricos da plataforma [Desenvolvedor.io](https://desenvolvedor.io/)

# DDD

* Não é uma arquitetura
* São formas de modelagem de software focando na complexidade da aplicação. Não é uma receita de bolo.
* Foca no conhecimento do domínio e através disso monta o design da aplicação.
"Toda arquitetura é design, mas nem todo design é arquitetura" Grady Booch
* Para aplicar o DDD, você deve identificar por conta próprio a necessidade de implementar ou não. Se aplicar sem necessidade, vai transformar a aplicação simples em uma aplicação complexa.
* Indicado para aplicações complexas, com muitas entidades e regras de negócios.
* Pontos chaves do DDD: Linguagem úbiqua, Bounded Contex e Contex Map.


# Linguagem úbiqua
* É uma linguagem universal falada dentro da empresa e que todos compreendam.
* Usada em todas as formas faladas e escritas dentro da empresa.
* Dependendo do ponto de vista, cada pessoa tem uma visão diferente. Isso falta muito em empresas, nem todos os colaboradores sabem como funciona o processo por completo dentro da empresa.
* Depois que você começa a entender melhor a linguagem, você começa e entender melhor o domínio da aplicação e como montar o design da aplicação.
* É uma linguagem natural, não artificial.  Obtida em reuniões e brainstormings.
* Vai sendo composta e refinada com o tempo
* O Código Fonte também deve utilizar linguagem ubiqua. O código deve refletir a linguagem.
* [SlimWiki](https://slimwiki.com/), ferramenta para montar documentação da linguagem ubiqua. É um Wiki mais simples.
* Sempre manter a padronização do idioma. Não misturar diversos idiomas.

# Modelagem Estratégica
* É um ponto crucial, importantissimo.
* Context Map, é o resultado final da modelagem estratégica. 
* Bounded Contex: 
    * contexto delimitado onde um elemento tem um significado bem definido. E cada um tem sua linguagem ubiqua.
    * domínio da aplicação dividido em varios contextos, formando uma teia. Cada um tem sua arquitetura e implementação.
    * Remove a ambiguidade e duplicação de código
    * Simplifica o design dos módulos
    * Integra com componentes externos
    * Modelo de Negócio, é o PRODUTO (modelo do mundo real) que se deseja entregar, exemplo, um carro. Existem várias áreas ao redor desse carro para que ele seja desenvolvido e entregue. 
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Vendas, marleting, preço, estoque, etc.... Se não tiver uma quebra em vários dominios, a aplicação será uma grande bola de Lama (BIg Ball of Mud)
    * Modelo de Dominio, é um modelo de negócio quebrado em vários pedaços, para cada área da empresa, esse mesmo PRODUTO tem um caracteristica diferente, o que realmente faz sentido para aquele dominio.
* Tipos de Relacionamentos entre contextos
    * contextos Upstream influenciam contextos DownStream. Mudanças efetuadas no Upstream podem mudar o DownStream, mas o inverso não é verdadeiro.
    Essas mudanças podem ocorrer em binários, mudanças, cronograma.
    * Tipo de relacionamento Cliente-Fornecedor: é quando um contexto consome informações do outro. Exemplo, contexto de Vendas e Fiscal. O Contexto Fiscal é Cliente de Vendas e esse é fornecedor para o Fiscal. Pq o fiscal consome as informações de vendas para processar notas, impostos, etc....
    Contextos Clientes dependem de Contextos Supplier.
    Os testes de integração servem para validar a integração entre os contextos.
    * Tipo de relacionamento Parceiro: não existe direção, são iguais. Se um contexto muda, o outro também muda.    
    * Tipo de relacionamento Conformista: se um contexto mudar, você simplesmente vai ter que se conformar que mudou e fazer as adequações. Nenhuma negociação é permitida.
    Muito comum em integração externa. É comum utilizar uma Camada Anti-Corrupção nesse cenário para receber os objetos e fazer as transformações em objetos que serão enviados para o exterior.
    Caso a integração com o exterior mude, a alteração deve ser efetuada somente nessa camada. Traduz de um mundo para outro mundo.
    * Tipo de relacionamento Conformista: Nucleo Compartilhado, se sofrer alterações, vai impactar em todos os outros contextos. Qualquer alteração a ser realizada nesse contexto, deve ser verificado com os demais contextos para verificar se não irá quebrar.
    * Tipo de relacionamento Anti-Corrupção: Camada adicional dando ao contexto DownStream uma interface fixa independente do que acontece com contexto upstream.
    Garante que alterações externas não impactem nos contextos internos. Somente nessa camada.

# Estilos e padrões arquiteturais
*  Evolução: 
    * Arquitetura orientada a spaguetti (Código macarrônico), 
    * Arquitetura orientada a lasanha (monolito separada em camadas) 
    * Arquitetura orientada a ravioli (microserviços)
    * Analogia muita massa para entender
* Como definir um Estilo
    * Entender o negócio (UX, Use-Cases, Negócio, Persistência)
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;E depois de entender o negócio, entender qual melhor padrão se adequa a sua necessidade.
    Negócio > Padrões (Transaction Script, Table Module, Domain Model, CQRS, Event Sourcing)
* Transaction Script: idéia é criar métodos para resolver um problema. Muito utilizado em aplicações desktop ou MVC tbm pode ser considerado esse padrão.
* Table Module Pattern: um módulo por tabela no banco de dados. Os módulos possuem todos os métodos que processam os dados. Consultas e processamento.
* Domain Model Pattern: defendido pela abordagem DDD. É um conjunto de padrões.
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Aggregate objects: uma entidade que representa um conjunto de entidades. Possui dados e comportamentos. Utiliza persistência Agnóstica, não sabe como os dados são persistidos. E está alinhado com os serviços de domínio.
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Proposta de camadas: Presentation, Busines (Application e Domain), Infrastructure (IoC, Cache, Repositories)
* Arquitetura Cebola (Onio Architecture): conceito que tem manter a arquitetura limpa. Camadas que podem ser acessadas através das outras interfaces.
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Domain < Domain Services < Application Services < Infra/User interface
* Arquitetura Hexagonal (portas e adaptadores) : Mistura de Onion, DDD, Clean, CQRS tudo junto..
    
    Hexagonal é para dar o entendimento que possui portas e adpatadores que você pode ir acoplando funcionalidades.
    
    Porta, poderia ser a aplicação MVC ou o ponto de entrada
    
    Adaptadores, poderia ser o Application services
    
    A arquitetura exagonal se mistura com a arquitetura cebola. Tem que entender que a diferença entre elas é se você possui essas portas e adapter para acoplar.
* Camada de Presentation: pode ser um MVC, API, SPA, etc.
* Camada de Aplicação: não precisa ser um projeto dentro da arquitetura. Pode ser um controller, views, etc. 
* Camada de Domínio: Trabalha com Entidades, fabricas, objetos de valor, serviços de domínio, etc... Tem dados e comportamentos nas entidades
* Camada de Infraestrutura: é uma super camada que pode englobar, persistência, segurança, logging, IoC, Caching, etc....
    
    Dica: isole os detalhes, exemplo: connection  string, file paths, HTTP urls, etc....

# Modelam tática
*   Domain Module: 
    * Agregados:
    * Entidades:
    * Objetos de valor: 
    * Fabricas:
* Objetos de valor: agrega valor a alguma coisa. É uma coleção de dados individuais, destinado para ser uma coleção de atributos, imutável e com maior precisão do que os tipos primitivos.
* Entidades: representam alguma coisa do mundo real. Deve possuir identidade, exclusiva para o objeto mapeado, possui estados e comportamentos e possui lógica de negócio.
* Agregações: Conjunto de entidades usadas e referenciadas juntas, tratada como uma só quando o dado é alterado, possui uma raiz de agregação (aggregate root) e a raiz de agregação mantém a integridade das classes filhas. Uma entidade é mutável, diferente do objeto de valor. Regra: Utilize um unico repositorio por agregação.
* Serviços de dominio: implementam lógica que não pertencam a um agregado e trabalham com multiplas entidades. Coordenam as atividades dos agregados e repositorios com o propósito de implementar a ação de negócio e podem consumir serviços da infra (envio de e-mail, eventos ou mensagens)
* Repositorios: cuida da persistência. Possuem dependência direta com o meio de acesso a dados. Pode ser genérico, especializado herdando do genérico, pode conectar diretamente ao banco e trabalhar com ADO, pode utilizar ORM, pode consulta serviço externo. Ele somente deve retornar dados
* Eventos de domínio: oferecem uma resiliência efetiva para expressar comportamentos.


# Criação do Projeto via DotNet CLI

* Para criar a solution. Utilizei a tag **--name** para definir o nome da minha solution.
```
dotnet new solution --name NerdStore
```

Depois de criar a solution, adicionei duas pastas. Uma **src** para colocar os fontes e uma **test** para ficar os testes.
Fiz uma separação física ainda dentro da pasta **src** para separar os serviços dos webapps.

A estrutura final das pasta ficou dessa forma.

![estrutura](https://i.imgur.com/byD7x0q.png)

Depois acessei a pasta *Catalogo* e criei uma ClassLib Domain.

```
dotnet new classlib --name NerdStore.Catalogo.Domain
```

E por fim, adicionei esse projeto ao *Solution*.

```
dotnet sln .\NerdStore.sln add .\src\Services\Catalogo\NerdStore.Catalogo.Domain\NerdStore.Catalogo.Domain.csproj
```

E assim fiz para os projetos necessários.

Para adicionar uma referência a outros projetos via CLI, estando dentro da pasta do projeto que deseja adicionar a referência.

```
dotnet add .\NerdStore.Catalogo.Domain.csproj reference ..\..\Core\NerdStore.Core\NerdStore.Core.csproj
```


Para criar o projeto MVC para construir a interface
```
dotnet new mvc --name NerdStore.WebApp.MVC --auth Individual 
```

Para subir o EventoStore para persistência dos Eventos
```
docker-compose up
```

# CQRS
* Design Pattern
* Alterações realizadas pelos Commands. Leitura realizada pela Queries
* Provem a expressividade da aplicação, pois todo command representa a intenção de negócio
* Promove consistência eventual dos dados quando possui um banco de leitura e outro de escrita com os mesmos dados.
* Utilizado em arquiteturas Hexagonais, microservices ou aplicações com alta demanda de consumo de dados.
* Commands
    * Intenção de mudança no estado de uma entidade
    * Expressivos e representam uma intenção de negócio
* Queries
    * Forma de obter dados de um banco ou origem de dados (Rest)

# Teorema CAP
* 3 fundamentos
    * Consistência (COnsistency)
    * Disponibilidade (Availability)
    * Tolerância a falha (Partition Tolerance)
* Somente posso trabalhar com dois fundamentos
    Consistência <-> Disponibilidade (CA)
    Consistência <-> Tolerância falhas (AP)
    Disponibilidade <-> Tolerância falhas (CP)
    Ideal é ter disponibilidade e tolerância a falhas. A consistência uma hora você vai ter (Consistência eventual)

# EventSourcing
* Persistência dos eventos que ocorreram na entidade durante a vida dela.
* EventStore para armazenar esses eventos que foram gerados.



## GitFlow
teste 1
teste 1.1

teste 2
teste 2.1