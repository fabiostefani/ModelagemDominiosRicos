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
        