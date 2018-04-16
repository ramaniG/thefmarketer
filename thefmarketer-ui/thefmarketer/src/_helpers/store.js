import { createStore, applyMiddleware } from 'redux';
import thunkMiddleware from 'redux-thunk';
import { createLogger } from 'redux-logger';
import { routerMiddleware } from 'react-router-redux'
import rootReducer from '../_reducers';
import { history } from './history'

const loggerMiddleware = createLogger();

// Build the middleware for intercepting and dispatching navigation actions
const middleware = routerMiddleware(history)

export const store = createStore(
    rootReducer,
    applyMiddleware(
        thunkMiddleware,
        loggerMiddleware,
        middleware
    )
);
