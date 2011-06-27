# PROMPT11-02-AdvancedProgramming.vilhena - Projecto Final #

# Autor #

Gonçalo Vilhena

## Arquitectura ##

### Componentes ###

 * Injector
  * Entidade que resolve os tipos, chama o TypeResolver para tratar o pedido

 * Binder
  * Classe parcial que contem a estrutura de dados que suporta os binds dos tipos
  * Composto por mais 3 classes parciais onde está definida a linguagem fluente TypeBinder, ActivationBinder e ConstructorBinder
  * Contem um contentor de TypeConfiguration

 * TypeConfiguration
  * Objecto do modelo contentor dos dados necessários para construir um objecto de um determinado tipo

 * TypeResolver
  * Classe responsável por identificar a configuração do tipo e executar o pipeline de resolução, resolve o construtor caso não esteja presente
  * Utiliza um ActivationPlugin para cada tipo configurado para assegurar a estratégia de instanciação
  * Utiliza um ExpressionRecorder que permite ajudar a gravar a sequências de instanciação/inicialização

 * ExpressionRecorder
  * Classe que contêm uma stack de execução da sequência de pedidos executados pelo TypeResolver
  * Esta classe é responsável por gerar uma Expression no final de um pedido
  * A estratégia de instanciação é questionada ao ActivationPlugin

## Compromissos ##

 * O código gerado utilizando expressions em alguns casos não é óptimo, por exemplo A(B(),C(B)), neste caso o código gerado seria:

`var1 = new B()`
`var2 = new C(var1)`
`var3 = new A(var1, var2)`
`ret var3`
  * este código é optimo mas caso o objecto A seja configurado como singleton então o código gerado será:
`var1 = new B()`
`var2 = new C(var1)`
`var3 = .Constant(objecA)`
`ret var3`
  * Assim podemos ver que a criação das variáveis 1 e 2 são desnecessárias. Esta situação poderia ser contornada utilizando mais alguma lógica no momento de geração do código

 * No exemplo acima podemos também identificar que a criação da variável 3 é desnecessária, assim como a variável 2 que podia ser incluída directamente no construtor do A, isto acontece porque podemos em alguns objecto necessitar de inicializar campos ou propriedades 

 * O pipeline de resolução de tipos é estático, seria interessante implementar um pipeline dinâmico.


## Testes Adicionais ##

 * Foi implementado um teste que permite comparar a performance do gerador de código, os resultados mostraram que a construção dos novos objectos usando o injector é 10 vezes superior ao utilizar o código directamente. Quando comparamos com o código sem código gerado a ordem de grandeza sobe aos 3 dígitos.
 
## Notas ##

 * Num projecto futuro onde sejam utilizados acessos a bases de dados ou outro tipo de estruturas seria interessante validar a utilidade dos intectors no que diz respeito a facilitar testes com a utilização de mock objects.
