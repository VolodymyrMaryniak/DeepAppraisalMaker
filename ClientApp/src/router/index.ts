import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/counter',
    name: 'counter',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "counter" */ '../views/Counter.vue')
  },
  {
    path: '/fetch-data',
    name: 'fetch-data',
    component: () => import(/* webpackChunkName: "fetch-data" */ '../views/FetchData.vue')
  },
  {
    path: '/quizzes',
    name: 'quizzes',
    component: () => import(/* webpackChunkName: "quizzes" */ '../views/Quizzes.vue')
  },
  {
    path: '/quiz-details/:quizId',
    name: 'quiz-details',
    component: () => import(/* webpackChunkName: "quiz-details" */ '../views/QuizDetails.vue')
  }
]

const router = new VueRouter({
  mode: 'history',
  routes
})

export default router
