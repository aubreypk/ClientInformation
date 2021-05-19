/*import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/list',
    name: 'list',
    component: () => import('../components/ClientList')
  },
  {
    path: '/new',
    name: 'new',
    component: () => import('../components/ClientCreate')
  },
  {
    path: '/edit/:id',
    name: 'edit',
    component: () => import('../components/ClientEdit')
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router*/

import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    name: 'list',
    component: () => import('../components/ClientList')
  },
  {
    path: '/new',
    name: 'new',
    component: () => import('../components/ClientCreate')
  },
  {
    path: '/edit/:id',
    name: 'edit',
    component: () => import('../components/ClientEdit')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
