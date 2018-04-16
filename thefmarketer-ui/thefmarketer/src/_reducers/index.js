import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux'
import { authentication } from './authentication.reducer';
import { alert } from './alert.reducer';

const rootReducer = combineReducers({
  authentication,
  alert,
  router: routerReducer
});

export default rootReducer;
