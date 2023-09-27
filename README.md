# About
Welcome to lovelive.cz repository! This repository contains source files of https://next.lovelive.cz website, which is a fan-made website for (not only) Czech Love Live! enthusiasts. We want to create a nice and comfy place for everyone to share thoughts, questions or basically anything else you want! We are pretty early in development, but we are working on it!

## Current goals
There are several goals we would like to achieve before making the website truly public. Pointing out everything that needs to be done individually is pretty much pointless, so lets say we just need to have a nice fundation we can build on in the future.

# Contributing
Any kind of contribution and help is welcomed! There aren't any special rules when it comes to contributing. The easiest how to contribute is creating an issue when you have a feature proposal or when you find any kind of bug. If you'd like to contribute to the code base itself, feel free to create Pull Request and we'll check it out! Before doing so, please test your code to check if it really work and also check the linters. We won't accept PRs with linter warnings and errors!

## Running the code
When it comes to contributing, one of the main parts is testing your changes.. but how do you do that? Let's see.

### Frontend
To successfully run frontend locally, you'll need to do this:
1. Download and install the latest version of [Node.js](https://nodejs.org/en)
2. Clone the repository
3. Open any kind of terminal and go to `frontend` folder
4. Run `npm install` command and wait until everything is installed
5. Run `npm run dev` command
6. You should see a localhost link there, open it.
7. Check out your local version of the website!

NOTE: You won't be able to perform some actions without a backend server running locally too. To run backend locally, check out the next section.

### Backend
To successfully run backend server locally, you'll need to do this: 
1. Download and install [Docker](https://www.docker.com/products/docker-desktop/)
2. Add `127.0.0.1 database-postgresql` line to your [hosts](https://docs.rackspace.com/docs/modify-your-hosts-file) file
3. Clone the repository
4. Open any kind of terminal and go to `backend` folder
5. Run `docker compose -f docker-compose.Development.yaml up -d` command
6. Backend server should now be running!

NOTE: Server might crash on start-up if it starts before database initializes and starts accepting connections. If this happens, simply try running `docker compose -f docker-compose.Development.yaml up love-live-cz-api -d` command to start it again.
