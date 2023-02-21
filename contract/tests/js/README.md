# NodeJs Version

minimum js version v12.22.7

# Package Guide

- `test`: Contains automated go tests for testing the functionality
  of the smart contracts.

# Commands to Run test Cases

- First you need to move test/js directory by following command from root

  ```sh
      cd ./test/js
  ```

- We need to create flow-config `flow.json` file to run emulator and manging accounts and contracts
  ```sh
      flow init
  ```

- Now we are good to go to run our tests 
  ```sh
      ./index.sh
  ```

