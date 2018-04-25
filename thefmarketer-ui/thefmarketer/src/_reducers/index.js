import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux'
import { authentication } from './authentication.reducer';
import { search } from './search.reducer';
import { alert } from './alert.reducer';

const rootReducer = combineReducers({
  authentication,
  alert,
  search,
  router: routerReducer
});

export default rootReducer;
