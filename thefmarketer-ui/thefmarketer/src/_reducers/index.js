import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux';

import { admin } from './admin.reducer';
import { alert } from './alert.reducer';
import { auth } from './auth.reducer';
import { consultant } from './consultant.reducer';
import { membership } from './membership.reducer';
import { user } from './user.reducer';


const rootReducer = combineReducers({
  admin,
  alert,
  auth,
  consultant,
  membership,
  user,
  router: routerReducer
});

export default rootReducer;
