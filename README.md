# PaymentGateway
Payment gateway to process payment and view payment history

### Pre-requisites
I have used .net 6.0 to create the web api and used nunit 3 to run unit tests. 

### Compile 
Please make sure you have installed all the relevany dependencies and code compiles without any issues

### Run
Please set PaymentGatewayApi as default project and hit F5, which will launch a browser and load the api documentation; I have use Swagger UI for this.


![Swagger UI](https://github.com/vmyilsamy/PaymentGateway/assets/9333379/d46fde79-125e-4ab3-b9a5-627954c38e01)


### Considerations

-- I have split the payment processing and history in two different routes, this will help us scale quite efficiently given most of the time we get more calls to process payments compared to fetching the history.

-- Payment request I have not tied that to a specific merchant with merchant id or some key, in real world scenario we need to know who initiated the payment

-- I've mocked the acquiring bank client, which can be replaced with actual client given the request / response contract is same. For testing purpose I have set amount from 1 to 3 to check the different payment status

-- Unit test I've followed BDD style unit testing which is quite efficient to manage in the long run, when things are complicated this style of unit test will definitely help

As you can below the unit test output clearly states what the intention of the test. This helps in the long run.

![BDD style nunit tests](https://github.com/vmyilsamy/PaymentGateway/assets/9333379/98af1380-4582-4033-bea1-3fb748e3cb3c)


### Given more time, things I would like to do...
- More model validation
- Better API documentation
- Add resilience by using Polly
- Add security (authentication and authorisation)
- Include loggine middleware using Serilog
- Add more unit tests for service and components
- Add integration tests if necessary
- Add acceptance tests to cover the business acceptance criteria
- Assuming  there are SLAs to the acquiring bank service, based on that we can either use messaging or transient retries.

PS: I tried to complete the test within specifiec time, which I have. Many thanks for the opportunity.
