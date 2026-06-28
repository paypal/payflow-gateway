Payflow Java SDK
----------------

A simple SDK allowing easy integration with the Payflow Gateway for Java.

> THIS VERSION IS NOT 100% COMPATIBLE WITH OLDER VERSIONS AS SOME OF THE OBJECTS AND THEIR LOCATIONS HAVE MOVED.
> DO NOT COPY THE JAR INTO A PRODUCTION ENVIRONMENT WITHOUT ADJUSTING YOUR CODE IF NECESSARY AND TESTING.

## Supported Platforms

Java 11 or newer (LTS releases recommended). Java 8 will also work if you set `maven.compiler.release` to `8` in `pom.xml`.

## Building with Maven

The recommended way to build the SDK is with [Apache Maven](https://maven.apache.org/) 3.6+.

```bash
cd java
mvn clean package
```

This produces `target/payflow.jar` with no external dependencies. Copy it to your project's classpath.

## Building with an IDE

Open the `java/` directory as a Maven project in IntelliJ IDEA, Eclipse, or VS Code (Java Extension Pack). The IDE will automatically detect `pom.xml` and configure the source roots.

## Running the Samples

The sample files live under `src/paypal/payments/samples/`. They are not included in `payflow.jar`; compile and run them directly:

1. Build the SDK first: `mvn clean package`
2. Open the sample you want to run (e.g., `src/paypal/payments/samples/dataobjects/basictransactions/DOSaleComplete.java`)
3. Fill in your Payflow credentials where prompted
4. Compile and run with `payflow.jar` on the classpath:

```bash
javac -cp target/payflow.jar src/paypal/payments/samples/dataobjects/basictransactions/DOSaleComplete.java
java  -cp target/payflow.jar:src DOSaleComplete
```

## Documentation

See the [Payflow Gateway Developer Guide](https://developer.paypal.com/docs/payflow/integration-guide/).

## Development

Please feel free to follow the [Contribution Guidelines](./CONTRIBUTING.md) to contribute to this repository. PRs are welcome, but for major changes please raise an issue first.

## Older Versions

The last builds of the v4 SDKs are located in the [SDK Binaries](https://github.com/paypal/payflow-gateway/tree/master/SDK%20Binaries/) directory.

## License

Code released under [SDK LICENSE](https://github.com/paypal/payflow-gateway/blob/master/LICENSE).
