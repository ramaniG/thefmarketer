import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux'
import { auth } from './auth.reducer';
import { alert } from './alert.reducer';

const rootReducer = combineReducers({
  auth,
  alert,
  router: routerReducer
});

export default rootReducer;
