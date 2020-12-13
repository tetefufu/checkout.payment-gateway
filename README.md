<!-- ABOUT THE PROJECT -->
## About Checkout.Payment-Gateway

E-Commerce is experiencing exponential growth and merchants who sell their goods or services online need a way to easily collect money from their customers.

Checkout.Payment-Gateway is a payment gateway, an API based application that allows a merchant to offer a way for their shoppers to pay for their product.

### Built With

* [.NET Core](https://google.com)
* [DBLite](https://google.com)
* [Swagger](https://google.com)
* [Docker](https://google.com)


<!-- GETTING STARTED -->
## Getting Started

### Prerequisites

* Visual Studio
* .NET Core SDK
* Docker (optional)

### Installation

1. Clone the repo
2. Install nuget packages
3. Build and Run

## Usage

See swagger link which opens by default when run via Visual Studio
https://localhost:44398/swagger/index.html
```
GET /Payments/{paymentId}
POST /Payments
```

## Assumptions

- Only three possible responses from real banks: (Success, Invalid, Declined)
- an implementation of IBank will be built for the actual bank used in production

## Roadmap

* Handle CC holder's address
* use CC validator https://github.com/gustavofrizzo/CreditCardValidator to validate CC number
* Error middleware to return proper http error codes (e.g. 40X for validation errors)
* Resiliant database implementation (e.g. AWS DynamoDB)
* Less use of primitives
* config via docker parameters
* config via appsettings
* Mediatr
* Delete test data of integration tests
* Performance testing
  * process requests/sec
  * query requests/sec
* Authentication 
* Encryption
* Assert that multiple validation errors are shown 
* Assert that HTTP code is 40X for validation errors 
* Build script / CI

### Ideal Architecture

The scaling requirements of this API lends itself well to using serverless technologies on AWS

![alt text](https://miro.medium.com/max/1220/1*VfuuRdNeVHEFnl8sdctpjg.png)

## License

Distributed under the MIT License. See `LICENSE` for more information.

