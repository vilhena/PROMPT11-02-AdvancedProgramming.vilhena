# PROMPT11-01-VMEssentials.vilhena - Projecto Final #

# Autor #

Gonçalo Vilhena

## Arquitectura ##

### Componentes ###

 * HttpReflector
  * Console Application responsável pelo carregamento dos vários componentes

 * Controler
  * Entidade responsável por comunicar e interligar os vários componentes.
  * Implementação ReflectorController da interface IController
  * Constituido por um IRouter e um IUIBinder
  * Recebe pedidos do UIBinder através de uma Callback registada, encaminha o pedido para o Router e devolve a resposta ao UIBinder
  * Executa o IHandler devolvido pelo router e faz Bind à IView retornada pelo IHandler o que permite devolver o output ao UIBInder, neste caso HTML

 * UIBinder
  * Entidade que recebe pedidos do utilizador e produz os outputs para os utilizadores
  * Implementa a interface IUIBinder que tem um start, um stop e um Handler de pedidos
  * Implementação HttpBinder para tratar os pedidos e respostas Http
  * Nesta implementação a callback está implementada dentro do controller

 * Router
  * Entidade responsável por armazenar pares de Rotas e Tipos
  * Implementação ReflectorRouter da interface IRouter
  * Constituido por uma IRouteContainer, colecção de armazenamento de rotas
  * Recebe um pedido encaminha a rota ao IRouterCollection e devolve um IHandler
  * Nesta implementalção o IRouteContainer é uma implementação com Dicionário (RouteList)
  * O RouteList é um container de pares Rotas -> Type, onde o type é o tipo do objecto que deve ser instanciado e devolvido ao controller
  * Recebe do RouteContainer um RouteResult, o qual é constituido por um Mapa <pattern, valor> encontrado pelo pattern e o Objecto guardado no RouteContainter, neste caso o tipo do Handler
  * Utiliza uma função que implementa a interface IHandlerMapBinder que permite fazer bind às propriedades ao Handler das chaves encontradas no pattern 

 * RouteContainer
  * Container Genérico de armazenamento de rotas
  * Implementação da RouteList a interface IRouteContainer
  * Regista rotas com patterns com um Type associado, neste caso o tipo do IHandler a ser executado
  * Retorna um RouteResult

 * Handlers
  * Entidades que contêm as acções necessárias executar sobre o AssemblyModel (responsável por retornar os tipos carregados)
  * Impementa a interface IHandler, que é constituida por um método Run que retorna uma IView
  * A View retornada devolve todos os dados necessários para para o output do utilizador
  * Cada Handler tem a sua implementação para cada pedido, contendo as propriedades necessárias para tratar os seus pedidos
  * Cada propriedade está anotada com a pattern correspondente das rotas
  * Os Handlers utilizam uma classe auxiliar que é responsável por carregamento e revolver objectos do modelo de negócio, neste caso os objectos de reflexção. Esta classe do que trata da lógica do negócio é a AssemblyModel

 * AssemblyModel
  * Classe que contém a estrutura de objectos de reflecção.
  * Utiliza a implementação genrérica de Tree para guardar os namespaces
  * Utiliza lazyload para o carregamento dos tipos

 * Views
  * Entidades que têm as projecções dos dados necessários para produzir o output dos dados
  * Implementam a interface IView
  * Para cada view existem ficheiros (neste caso txt) que contêm a descrição do output a ser produzido. Estes ficheiros estão localizados na pasta HttpReflector\Test\Views
  * Está implementada uma classe ViewBinder que faz o bind dos dados presentes nas IViews com os txt com a estrutura dos outputs
  * O bind correspondente ao tipo da da view é feito pelo nome, pelo que por exemplo, se estiver a utilizar uma AssemblyView o template terá que se chamar AseemblyView.txt
  * Podemos utilizar os templates os seguintes atributos especiais
   * <$Caminho.Para.A.Propriedade> - Permite substituir esta tag pelo valor definido na propriedade acedida por Caminho.Para.A.Propriedade
   * <@PropriedadeColecção> - Permite iterar sobre a colecção, para isso utiliza o que está definido num template auxiliar para produzir o output para cada item da lista, esses templates têm o nome original da View.PropriedadeColecção.txt. Permite acesso recursivo se cada item utilizar uma lista podemos definir outro subtemplate
   * <%Caminho.Para.A.Propriedade.Root> - Criado para permitir aceder às propriedades da view original quando estamos a iterar sobre um elemento de uma lista da view

 * Utils
  * Contém uma implementação genérica de uma Tree<TKey, TValue> que permite guardar TValues, indexados em árvore pelas TKeys

 
### Exemplo de um Pedido ###

 * 1 - Pedido Http GET do cliente ao endereço http://localhost:8080/system32
 * 2 - O pedido é rerireccionado para a Waitcallback registada no ReflectorControllor com o nome ProcessRequest
 * 3 - O ProcessRequest chama o método Router.Route com o URL system32
 * 4 - O Router chama o método this._route.Seek do objecto IRouteContainer<Type> com o URL passado
 * 5 - O RouterContainer (implementado em lista) percorre o dicionário de patterns e identifica a rota correspontente
 * 6 - O método Seek do RouterCollection revolve um RouteResult com um Map (dicionário de chave, valor com os pares patter e valor do URL encontrado) e o Type do handler específico responsável por tratar os dados, neste caso o ContextHandler
 * 7 - O Router do controller cria uma instância do tipo devolvido pelo Router, Activator.CreateInstance(result.Handler)
 * 8 - Chama o método _binder.Bind(result.Map, handler) sobre o handler instanciado e o mapa, fazendo o match da propriedade [HandlerMapAttribute("{ctx}")] com o nome Context afectando o valor system32 definido no Map
 * 9 - Devolve o ContextHandler ao Controller
 * 10 - O ReflectorController executa o método Run() sobre o ContextHandler
 * 11 - O ContextHandler na implementação do método Run() chama o serviço AssemblyModel.GetContext(Context) para obter o contexto e em seguida executa o método AssemblyModel.ListNamespaces(Context) para obter a lista dos namespaces do contexto system32
 * 12 - Utiliza o Objecto Context e a lista de Namespace e cria um objecto ContextView com estes dados, esta view é devolvida ao ReflectorController
 * 13 - O ReflectorController executa o método ViewBinder.BindView(view) sobre a view fazendo o bind de propriedades e chaves definidos no ficheiro /Test/Views/ContextView.txt (que é encontrado utilizando o mesmo nome do tipo da view)
 * 14 - Como o ficheiro ContextView.txt têm por exemplo uma tag <@Assemblies> então vai iterar sobre a lista de Assemblies da view e para cada Assembly vai produzir a substituição das tags definidas no ficheiro ContextView.Assemblies.txt
 * 15 - No final do Bind é devolvido ao Controller a string que contêm o HTML com a resposta
 * 16 - O controller devolve a resposta do Binder na Response do pedido get http

## Compromissos ##

 * Router implementado com uma implementação de IRouterCollection em Dicionário, existe uma outra implementação em Tree mas não está a funcionar correctamente, como o Router utiliza uma IRouterCollection é basta alterar uma linha de código para passar a utilizar uma implementação de IRouterCollection em Tree
 * O tratamento de excepções na UI é global pelo que não são diferenciados os diferentes pedidos por cada tipo de excepção. Estas excepões são tratadas de igual modo que qualguer pedido, pelo que o controller devolve sempre uma IView, que neste caso é uma ExceptionView onde é mostrada a mensagem da excepção ao utilizador, com a arquitectura implementada é bastante fácil extender para comportamentos diferentes de diferentes tipos de excepções
 * O carregamendo dos Tipos por reflecção foi implementado com um método recursivo, mas com implementação lazy, o que permite delegar a necessidade de carregar dados ao handler, neste caso a implementação do carregamento dos tipos é bastante lenta e identifiquei com o dotTrace que o bottleneck está na implemntação de um método que encontra para um tipo o namespace e o assembly, este método utiliza a Tree pelo que o FindNode também necessesitaria de optimização
 * O sistema de bind às Views permite através das tags fazer bind dos dados ao output a ser produzido, sendo assim possivel, produzir outputs totalmente costumizados. Tem a grande desvantagem de as tags mal declaradas não serem detectadas em tempo de execução 
 * Como os handlers têm os mapeamentos dos patterns das rotas descritas utilizando custom attributes, ficamos limitados a que cada handler só sabe trabalhar com determinado tipo de rotas, permitindo simplemente mudar a ordem ou forma dos URL, assim obriga a que a rota para o handler tenha obrigatóriamente todas as propriedades necessárias para handler, como é definido com custom attributes só é detectado em tempo de execução
 * A implementação de Tree seria interessante implementar utilizando iterators, utilizando uma abordagem lazy
 