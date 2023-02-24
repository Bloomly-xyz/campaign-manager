#!/bin/sh

#Author : Object Player
#Description: This script will run all test-cases step by step


#Create flow config file
flow init --reset

#Run flow emulator in new tab
gnome-terminal --tab --title=flowEmulator -- bash -c "flow emulator -v ; exec bash" 

#Run flow setup
npm test -- ./flow_setup/index.test.js -- --coverage -collectCoverageFrom=./flow_setup/index.test.js

#Run contract deployment
npm test -- ./contract_deployments.test.js -- --coverage -collectCoverageFrom=./contract_deployments.test.js

#Run utility user-stories
npm test -- ./UtilityTracker/user_stories.test.js -- --coverage -collectCoverageFrom=./UtilityTracker/user_stories.test.js


# #Close the emulator tab
# gnome-terminal --tab --title=flowEmulator -- bash -c "exit ; exec bash" 
